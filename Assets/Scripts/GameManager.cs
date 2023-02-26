using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public event EventHandler OnDeathNotifySFX;
    public event EventHandler OnScoreNotifySFX;
    public event EventHandler OnCoinCollectedNotifySFX;
    public event EventHandler OnWonNotifySFX;


    [Header("UI Screens")]
    [SerializeField] GameObject youWonScreen;
    [SerializeField] GameObject youLostScreen;
    [SerializeField] GameObject gameUIScreen;
    [SerializeField] GameObject countDownScreen;

    [SerializeField] GameObject pauseScreen;

    [Header("UI Elements")]
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] TMPro.TextMeshProUGUI wonScoreUIText;
    [SerializeField] TMPro.TextMeshProUGUI scoreUIText;
    [SerializeField] TMPro.TextMeshProUGUI coinUIText;
    [SerializeField] TMPro.TextMeshProUGUI wonCoinUIText;
    [SerializeField] TMPro.TextMeshProUGUI levelUIText;

    [Header("Game Objects")]
    [SerializeField] GameObject bricksHolders;
    [SerializeField] DeathZone deathZone;

    [Header("Paddle And Ball Related")]
    [SerializeField] Ball ball;
    [SerializeField] Paddle paddle;
    [SerializeField] Transform ballSpawnPoint;
    [SerializeField] Transform paddleSpawnPoint;
    [SerializeField] ItemSO[] items;

    [Header("Components")]
    [SerializeField] SFXManager sfxManager;
    [SerializeField] InputManager inputManager;
    [Header("Spawn Points")]


    int scoreCount = 0;
    int coinCount = 0;
    int brickCount;
    bool shouldPause = false;


    void Awake()
    {
        sfxManager = FindObjectOfType<SFXManager>();
    }

    void Start()
    {
        levelUIText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        string paddleID = PlayerPrefs.GetString("Paddle", "no_paddle");
        string ballID = PlayerPrefs.GetString("Ball", "no_ball");

        if (!ballID.Equals("no_ball") && !paddleID.Equals("no_paddle"))
        {
            foreach (ItemSO item in items)
            {
                if (ballID == item.id)
                {
                    Debug.Log("Found ball with id " + ballID);
                    GameObject obj = Instantiate(item.prefab, ballSpawnPoint.position, Quaternion.identity) as GameObject;
                    ball = obj.GetComponent<Ball>();
                    obj.SetActive(true);
                }
                if (paddleID == item.id)
                {
                    Debug.Log("Found Paddle with id " + paddleID);
                    GameObject obj = Instantiate(item.prefab, paddleSpawnPoint.position, Quaternion.identity) as GameObject;
                    paddle = obj.GetComponent<Paddle>();
                    obj.SetActive(true);
                    paddle.inputManager = inputManager;
                }
            }
        }
        else
        {
            GameObject ballObj = Instantiate(ball.gameObject, ballSpawnPoint.position, Quaternion.identity) as GameObject;
            GameObject paddleObj = Instantiate(paddle.gameObject, paddleSpawnPoint.position, Quaternion.identity) as GameObject;
            ballObj.SetActive(true);
            paddleObj.SetActive(true);
            ball = ballObj.GetComponent<Ball>();
            paddle = paddleObj.GetComponent<Paddle>();
            paddle.inputManager = inputManager;
        }


        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            inputManager.OnPauseResumePerformed += TogglePause;
            Brick.OnScoreUpdated += OnScoreUpdated_Action;
            deathZone.OnDeathRecieved += OnDeathRecieved_Action;
            countDownScreen.SetActive(true);
            brickCount = bricksHolders.transform.childCount;
            ball.StartGame(3);
        }
    }

    void TogglePause(object sender, EventArgs e)
    {
        shouldPause = !shouldPause;
        if (shouldPause)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }

    void OnDeathRecieved_Action(object sender, EventArgs e)
    {
        OnDeathNotifySFX?.Invoke(this, EventArgs.Empty);
        youLostScreen.SetActive(true);
        ball.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        Brick.OnScoreUpdated -= OnScoreUpdated_Action;
        deathZone.OnDeathRecieved -= OnDeathRecieved_Action;
    }

    void OnScoreUpdated_Action(object sender, Brick.OnScoreUpdated_EventArgs e)
    {
        brickCount--;
        scoreCount += e._points;
        scoreUIText.text = "Score: " + scoreCount;

        if (brickCount <= 0)
            HandleWonScreen();
        if (e.isCoinDrop)
            HandleCoinRecieved();
        else
            OnScoreNotifySFX?.Invoke(this, EventArgs.Empty);

    }

    void HandleCoinRecieved()
    {
        coinCount++;
        coinUIText.text = coinCount + " X";
        OnCoinCollectedNotifySFX?.Invoke(this, EventArgs.Empty);
    }

    void HandleWonScreen()
    {
        // Store Variables In PlayerPref
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coinCount);
        PlayerPrefs.SetInt("LastFinishedLevelIndex", SceneManager.GetActiveScene().buildIndex);

        // Handle And Update UI
        OnWonNotifySFX?.Invoke(this, EventArgs.Empty);
        ball.gameObject.SetActive(false);
        wonScoreUIText.text = "Score: " + scoreCount;
        wonCoinUIText.text = "X " + coinCount;

        // Enable UI
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelButton.SetActive(false);
        }
        youWonScreen.SetActive(true);
        gameUIScreen.SetActive(false);
    }

    public void HandleRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleLoadingNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HandleLoadingMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
