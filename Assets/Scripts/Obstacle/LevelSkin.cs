using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "CreateLevelSkin", order = 1)]
public class LevelSkin : ScriptableObject
{
    [SerializeField] private Mesh _skinMesh;
    [SerializeField] private Material[] _skinMaterial;
    [SerializeField] private Sprite _skinBackground;
    [SerializeField] private AudioClip _levelClip;
    [SerializeField] private int _scoreNeeded;

    public Mesh GetSkinMesh()
    {
        return _skinMesh;
    }
    public Material[] GetSkinMaterial()
    {
        return _skinMaterial;
    }
    public int GetSkinScore()
    {
        return _scoreNeeded;
    }
    public Sprite GetSkinBackground()
    {
        return _skinBackground;
    }
    public AudioClip GetSkinClip()
    {
        return _levelClip;
    }
}
