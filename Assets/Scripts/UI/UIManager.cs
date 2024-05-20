using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject IntroUI;
    public GameObject PlayUI;
    public GameObject SelectCharUI;
    public GameObject GameOverUI;

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

    public void SelectPopup(int num)
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

    public void OpenPopUp(int num)
    {
        if (num < 1 || num > 4) throw new ArgumentOutOfRangeException("num", "The popup number must be between 1 and 4.");
        UIArray[num-1].SetActive(true);
    }

    public void ClosePopUp(int num)
    {
        if (num < 1 || num > 4) throw new ArgumentOutOfRangeException("num", "The popup number must be between 1 and 4.");
        UIArray[num - 1].SetActive(false);
    }
}