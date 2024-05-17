using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;

    public AudioClip introBGM;  //인트로 브금
    public AudioClip playBGM;   //플레이 브금

    //효과음들
    public AudioClip gameOverSound;  //게임오버
    public AudioClip clickSound;    //버튼클릭
    public AudioClip onDamagedSound;    //피격
    public AudioClip useItemSound;    //아이템 사용
    public AudioClip gameClearSound;  //게임클리어

    //public AudioClip otherSound;  //다른 효과음들
    

    private void Awake()
    {
        //싱글톤 처리
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = introBGM;
        audioSource.Play();
    }

    public void ChangeBGM(AudioClip audioclip) //선택한 BGM 재생
    {
        //같은 BGM이 재생중이면 x
        if (audioSource.clip == audioclip && audioSource.isPlaying) return;
        audioSource.clip = audioclip;
        audioSource.Play();
    }

    public void PlaySoundOnce(AudioClip audioClip)  //사운드 1회 재생
    {
        audioSource.PlayOneShot(audioClip);
    }
}