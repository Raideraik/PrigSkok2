using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private AudioClip _startClip, _closeShopClip, _openShopClip;


    private void Start()
    {
        _bestScoreText.text = "Best\nScore\n" + PlayerPrefs.GetInt("BestScore").ToString();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartGame);
        _openShopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartGame);
        _openShopButton.onClick.RemoveListener(OpenShop);
        _closeShopButton.onClick.RemoveListener(CloseShop);
    }

    private void OpenShop()
    {
        _menuButtons.SetActive(false);
        _shopCanvas.SetActive(true);
        AudioController.Instance.PlayOnce(_openShopClip);
    }
    private void CloseShop()
    {
        _menuButtons.SetActive(true);
        _shopCanvas.SetActive(false);
        AudioController.Instance.PlayOnce(_closeShopClip);
    }

    private void StartGame()
    {
        AudioController.Instance.PlayOnce(_startClip);
        LoadMenu.Instance.ShowLoadingMenu();
        SceneManager.LoadSceneAsync(1);
    }
}
