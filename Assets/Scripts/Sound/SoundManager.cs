using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;

    public AudioClip introBGM, playBGM, clickSound, onDamagedSound, useItemSound, gameOverSound, gameClearSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBGM(AudioClip audioClip)
    {
        if (audioSource.clip == audioClip && audioSource.isPlaying) return;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlaySoundOnce(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayBGM(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PauseBGM()
    {
        if (audioSource.clip == null) return;
        audioSource.Pause();
    }

}