using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{

    [SerializeField] AudioClip[] sfxclips;
    GameManager gameManager;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource wonSource;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.OnDeathNotifySFX += OnDeathNotifySFX_Action;
            gameManager.OnScoreNotifySFX += OnScoreNotifySFX_Action;
            gameManager.OnCoinCollectedNotifySFX += OnGoldCollectedNotifySFX_Action;
            gameManager.OnWonNotifySFX += OnWonNotifySFX_Action;
        }
    }

    void OnWonNotifySFX_Action(object sender, EventArgs e)
    {
        wonSource.Play();
    }

    void OnGoldCollectedNotifySFX_Action(object sender, EventArgs e)
    {
        Play(sfxclips[1]);
    }

    void OnScoreNotifySFX_Action(object sender, EventArgs e)
    {
        Play(sfxclips[0]);
    }

    void OnDeathNotifySFX_Action(object sender, EventArgs e)
    {
        Play(sfxclips[2]);
    }

    public void Play(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
