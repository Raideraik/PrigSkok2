using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    private ChoosedSkin[] _choosedSkins;
    private PlayerMover _player;
    private void Start()
    {
        _choosedSkins = GetComponentsInChildren<ChoosedSkin>();
        _player = GetComponent<PlayerMover>();

        for (int i = 0; i < _choosedSkins.Length; i++)
        {
            _choosedSkins[i].gameObject.SetActive(false);
            if (_choosedSkins[i].GetID() == PlayerPrefs.GetInt("ChoosedSkin", 0))
            {
                _choosedSkins[i].gameObject.SetActive(true);
                _player.SetJumpClip(_choosedSkins[i].GetAudio());
            }
        }
    }
}
