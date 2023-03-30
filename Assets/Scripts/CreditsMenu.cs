using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _creditsMenu;
    [SerializeField] private Button _creditsButton;
    private void OnEnable()
    {
        _creditsButton.onClick.AddListener(OpenCloseCreditMenu);
    }
    private void OnDisable()
    {
        _creditsButton.onClick.RemoveListener(OpenCloseCreditMenu);
    }
    public void OpenCloseCreditMenu()
    {
        if (_creditsMenu.activeSelf || !_creditsMenu.activeSelf)
        {
            _creditsMenu.SetActive(!_creditsMenu.activeSelf);
        }
    }
}
