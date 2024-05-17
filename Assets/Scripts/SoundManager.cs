using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;

    public AudioClip introBGM;  //��Ʈ�� ���
    public AudioClip playBGM;   //�÷��� ���

    //ȿ������
    public AudioClip gameOverSound;  //���ӿ���
    public AudioClip clickSound;    //��ưŬ��
    public AudioClip onDamagedSound;    //�ǰ�
    public AudioClip useItemSound;    //������ ���
    public AudioClip gameClearSound;  //����Ŭ����

    //public AudioClip otherSound;  //�ٸ� ȿ������
    

    private void Awake()
    {
        //�̱��� ó��
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

    public void ChangeBGM(AudioClip audioclip) //������ BGM ���
    {
        //���� BGM�� ������̸� x
        if (audioSource.clip == audioclip && audioSource.isPlaying) return;
        audioSource.clip = audioclip;
        audioSource.Play();
    }

    public void PlaySoundOnce(AudioClip audioClip)  //���� 1ȸ ���
    {
        audioSource.PlayOneShot(audioClip);
    }
}