using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScore : MonoBehaviour
{
    public static MainMenuScore Instance { get; private set; }
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There more than one MainMenuScore!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _score = PlayerPrefs.GetInt("Score");
        UpdateScore();
    }
    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("Score", _score);
    }

    public bool TrySell(int score)
    {
        if (_score >= score)
        {
            _score -= score;
            UpdateScore();
            return true;
        }
        else
        {
            return false;
        }
    }

}
