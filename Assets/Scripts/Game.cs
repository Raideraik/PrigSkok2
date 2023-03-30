using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] private ObstacleGenerator _generator;
    [SerializeField] private Player _player;
    [SerializeField] private Screen _screen;
    [SerializeField] private AudioClip _gameOverClip, _buttonClip;

    [SerializeField] private int _neededScoreCount;
    private void OnEnable()
    {
        _screen.StartButtonClick += OnStartButtonClicked;
        _screen.ExitButtonClick += OnExitButtonClicked;
        _player.GameOver += OnGameOver;
        RewardedAds.OnPlayerGettingReward += GiveReward;
    }

    private void OnDisable()
    {
        _screen.StartButtonClick -= OnStartButtonClicked;
        _screen.ExitButtonClick -= OnExitButtonClicked;
        _player.GameOver -= OnGameOver;
        RewardedAds.OnPlayerGettingReward -= GiveReward;

    }


    private void Start()
    {
        Time.timeScale = 0;
        _screen.Open();
    }

    private void OnStartButtonClicked()
    {
        AudioController.Instance.ResetMusic();
        _screen.Close();
        _generator.ResetPool();
        StartGame();
    }
    private void OnExitButtonClicked()
    {
        Time.timeScale = 1;
        AudioController.Instance.PlayOnce(_buttonClip);
        SceneManager.LoadSceneAsync(0);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
    }

    public void OnGameOver()
    {
        if (PlayerPrefs.GetInt("LocalScore") >= _neededScoreCount)
        {
            _screen.ShowAdButton();
        }
        AudioController.Instance.ChangeMusic(_gameOverClip);
        Time.timeScale = 0;
        _screen.Open();
    }

    private void GiveReward()
    {
        _player.MultiplyScore();
    }
}
