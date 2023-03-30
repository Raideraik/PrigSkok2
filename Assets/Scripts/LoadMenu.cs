using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public static LoadMenu Instance;

    [SerializeField] private GameObject _loading;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There more than one LoadMenu!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void ShowLoadingMenu()
    {
        _loading.SetActive(true);
    }
    public void CloseLoadingMenu()
    {
        _loading.SetActive(false);
    }
   
}
