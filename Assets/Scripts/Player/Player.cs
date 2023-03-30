using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    //[SerializeField] private AudioClip _dieClip;

    private PlayerMover _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetPlayer();
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        PlayerPrefs.SetInt("LocalScore", _score);

        if (_score > PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", _score);

        _score += PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.SetInt("Score", _score);

        // AudioController.Instance.ChangeMusic(_dieClip);
        GameOver?.Invoke();

    }
    public void MultiplyScore()
    {
        int multiply = 2;
        _score *= multiply;
        ScoreChanged?.Invoke(_score);
        PlayerPrefs.SetInt("Score", _score);

    }


}
