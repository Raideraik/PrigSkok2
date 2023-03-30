using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffect;
    [SerializeField] private AudioClip[] _musicClip;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There more than one AudioController!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        ChangeMusic(_musicClip[Random.Range(0, _musicClip.Length)]);
    }

    public void PlayOnce(AudioClip audioClip)
    {
        if (_audioSourceEffect.clip != audioClip)
            _audioSourceEffect.clip = audioClip;

        _audioSourceEffect.Play();
    }

    public void ChangeMusic(AudioClip audioClip)
    {
        _audioSourceMusic.clip = audioClip;
        _audioSourceMusic.Play();
    }

    public void ResetMusic()
    {
        ChangeMusic(_musicClip[Random.Range(0, _musicClip.Length)]);
    }
}
