using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [SerializeField] GameObject homeScreen;
    [SerializeField] GameObject shopScreen;
    [SerializeField] GameObject continueButton;
    [SerializeField] TMPro.TextMeshProUGUI coinsText;
    [Header("Scripts")]
    [SerializeField] ShopManager shopManager;
    AudioSource audioSource;
    int coins;
    int LastFinishedLevelIndex;

    void Awake()
    {
        shopManager.OnCoinUpdate += HandleCoinUpdated;
        shopManager.OnButtonPressedSFX += HandleSFXPlay;
        LastFinishedLevelIndex = PlayerPrefs.GetInt("LastFinishedLevelIndex");
        if (LastFinishedLevelIndex <= 0 || LastFinishedLevelIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            continueButton.SetActive(false);
        }
        coins = PlayerPrefs.GetInt("Coins");
        audioSource = GetComponent<AudioSource>();
        UpdateCoinUI(coins);
    }

    void HandleSFXPlay(object sender, EventArgs e)
    {
        audioSource.Play();
    }

    void HandleCoinUpdated(object sender, EventArgs e)
    {
        coins = PlayerPrefs.GetInt("Coins");
        UpdateCoinUI(coins);

    }

    public void QuitApplication()
    {
        audioSource.Play();
        Application.Quit();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("LastFinishedLevelIndex", 0);
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(LastFinishedLevelIndex + 1);
    }

    public void ShowHomeScreen()
    {
        audioSource.Play();
        shopScreen.SetActive(false);
        homeScreen.SetActive(true);
    }

    public void ShowShopScreen()
    {
        audioSource.Play();
        homeScreen.SetActive(false);
        shopScreen.SetActive(true);
    }

    void UpdateCoinUI(int coins)
    {
        coinsText.text = coins.ToString();
    }
}
