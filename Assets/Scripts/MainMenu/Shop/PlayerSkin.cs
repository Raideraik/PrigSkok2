using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "CreatePlayerSkin", order = 1)]
public class PlayerSkin : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _picture;
    [SerializeField] private AudioClip _audioClip;

    public int GetID()
    {
        return _id;
    }
    public int GetPrice()
    {
        return _price;
    }
    public Sprite GetPicture()
    {
        return _picture;
    }
    public AudioClip GetAudio()
    {
        return _audioClip;
    }
}
