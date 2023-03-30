using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _effectsButton;
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Sprite[] _musicSprite;
    [SerializeField] private Sprite[] _effectsSprite;

    [SerializeField] private AudioClip _buttonClip;
    private void OnEnable()
    {
        _musicButton.onClick.AddListener(TurnMusic);
        _effectsButton.onClick.AddListener(SetEffects);
    }

    private void OnDisable()
    {
        _musicButton.onClick.RemoveListener(TurnMusic);
        _effectsButton.onClick.RemoveListener(SetEffects);
    }

    private void TurnMusic()
    {
        float minSound = -80f;
        float maxSound = -11f;
        _audioMixer.GetFloat("Music", out float volume);
        if (volume > minSound)
        {
            _audioMixer.SetFloat("Music", minSound);
            _musicButton.image.sprite = _musicSprite[1];

        }
        else
        {
            _audioMixer.SetFloat("Music", maxSound);
            _musicButton.image.sprite = _musicSprite[0];

        }
        AudioController.Instance.PlayOnce(_buttonClip);
    }

    private void SetEffects()
    {
        float minSound = -80f;
        float maxSound = 0f;
        _audioMixer.GetFloat("Effects", out float volume);
        if (volume > minSound)
        {
            _audioMixer.SetFloat("Effects", minSound);
            _effectsButton.image.sprite = _effectsSprite[1];

        }
        else
        {
            _audioMixer.SetFloat("Effects", maxSound);
            _effectsButton.image.sprite = _effectsSprite[0];
        }
        AudioController.Instance.PlayOnce(_buttonClip);

    }
}
