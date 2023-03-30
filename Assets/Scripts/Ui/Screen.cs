using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public event UnityAction StartButtonClick;
    public event UnityAction ExitButtonClick;
    //public event UnityAction AdsButtonCLick;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _adsButton;

    [SerializeField] private RewardedAds _rewardedAds;
    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _adsButton.onClick.AddListener(ShowAd);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _adsButton.onClick.RemoveListener(ShowAd);
    }
    public void Close()
    {
        _canvasGroup.alpha = 0;
        _startButton.interactable = false;
        _exitButton.interactable = false;
        _adsButton.interactable = false;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _startButton.interactable = true;
        _exitButton.interactable = true;
    }

    public void ShowAdButton()
    {
        _adsButton.interactable = true;
    }

    private void ShowAd()
    {
       // AdsButtonCLick?.Invoke();
        _rewardedAds.ShowAd();
    }
    private void OnStartButtonClick()
    {
        StartButtonClick?.Invoke();
    }
    private void OnExitButtonClick()
    {
        ExitButtonClick?.Invoke();
    }
}
