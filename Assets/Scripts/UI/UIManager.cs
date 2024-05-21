using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject introUI;
    public GameObject playUI;
    public GameObject selectCharUI;
    public GameObject gameOverUI;
    public GameObject selectDifficultyUI;

    public Dictionary<string,GameObject> uiDictionary;


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

        uiDictionary = new Dictionary<string, GameObject>
        {
            { "introUI", introUI },
            { "playUI", playUI },
            { "selectCharUI", selectCharUI },
            { "gameOverUI", gameOverUI },
            { "selectDifficultyUI", selectDifficultyUI }
        };
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void SelectPopup(string uiName)
    {
        if (uiDictionary[uiName] == null) Debug.LogError($"Key '{uiName}' does not exist in the dictionary.");
        foreach (KeyValuePair<string, GameObject> keyValuePair in uiDictionary)
        {
            if (keyValuePair.Key != uiName)
            {
                keyValuePair.Value.SetActive(false);
            }
            else
            {
                keyValuePair.Value.SetActive(true);
            }
        }
    }

    public void OpenPopUp(string uiName)
    {
        if (uiDictionary[uiName] == null) Debug.LogError($"Key '{uiName}' does not exist in the dictionary.");
        uiDictionary[uiName].SetActive(true);
    }
     public void ClosePopUp(string uiName)
     {
         if (uiDictionary[uiName] == null) Debug.LogError($"Key '{uiName}' does not exist in the dictionary.");
        uiDictionary[uiName].SetActive(true);
     }
}