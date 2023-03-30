using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanges : MonoBehaviour
{
    [SerializeField] private ObstacleGenerator _obstacleGenerator;
    [SerializeField] private LevelSkin[] _levelSkins;
    [SerializeField] private Player Player;
    [SerializeField] private Image _background;

    private int SkinIndex = 0;

    private void OnEnable()
    {
        Player.ScoreChanged += ChangeLevelLook;
        Player.GameOver += ResetLevelLook;
    }

    private void OnDisable()
    {
        Player.ScoreChanged -= ChangeLevelLook;
        Player.GameOver -= ResetLevelLook;
    }

    private void ChangeLevelLook(int score)
    {
        if (SkinIndex < _levelSkins.Length)
        {
            if (score == _levelSkins[SkinIndex].GetSkinScore())
            {
                for (int i = 0; i < _obstacleGenerator.GetPool().Count; i++)
                {
                    _obstacleGenerator.GetPool()[i].ChangeObstacle(_levelSkins[SkinIndex].GetSkinMesh(), _levelSkins[SkinIndex].GetSkinMaterial());
                    _background.sprite = _levelSkins[SkinIndex].GetSkinBackground();
                    AudioController.Instance.ChangeMusic(_levelSkins[SkinIndex].GetSkinClip());
                }
                SkinIndex++;
            }
        }
    }

    private void ResetLevelLook()
    {
        SkinIndex = 0;
    }

}
