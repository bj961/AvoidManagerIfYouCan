using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject IntroUI; //인트로창
    public GameObject PlayUI; //게임 플레이창
    public GameObject SelectCharUI; //캐릭터 선택창
    public GameObject GameOverUI; //게임오버창

    public static UIManager Instance { get; private set; }

    public GameObject[] UIArray;


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

        UIArray = new GameObject[4] {IntroUI, SelectCharUI, PlayUI, GameOverUI};
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void OpenPopup(int num)
    {   
        if (num < 1 || num > 4 ) throw new ArgumentOutOfRangeException("num", "The popup number must be between 1 and 4.");

        for (int i=0; i < UIArray.Length; i++)
        {
            if (i == num-1)
            {
                UIArray[i].SetActive(true);
            }
            else
            {
                UIArray[i].SetActive(false);
            }
        }
    }
}