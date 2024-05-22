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
    public GameObject singleCharSelectUI;
    public GameObject multiCharSelectUI;
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
            { "singleCharSelectUI", singleCharSelectUI },
            { "multiCharSelectUI", multiCharSelectUI },
            { "gameOverUI", gameOverUI },
            { "selectDifficultyUI", selectDifficultyUI }
        };

        if (introUI != null) return;
        RegisterUIObjects();
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
        uiDictionary[uiName].SetActive(false);
     }

    /// Find UI objects among the children of the UI root object 
    /// If the UI root object doesn't exist, search the entire hierarchy
    public void RegisterUIObjects()
    {
        GameObject uiRoot = GameObject.Find("UI");

        if (uiRoot != null)
        {
            introUI = FindImmediateChild(uiRoot.transform, "StartSceneCanvas");
            playUI = FindImmediateChild(uiRoot.transform, "MainSceneCanvas");
            singleCharSelectUI = FindImmediateChild(uiRoot.transform, "CharacterSelectSingleCanvas");
            multiCharSelectUI = FindImmediateChild(uiRoot.transform, "CharacterSelectMultiCanvas");
            gameOverUI = FindImmediateChild(uiRoot.transform, "EndPanelCanvas");
        }
        else
        {
            introUI = FindInactiveObjectByName("StartSceneCanvas");
            playUI = FindInactiveObjectByName("MainSceneCanvas");
            singleCharSelectUI = FindInactiveObjectByName("CharacterSelectSingleCanvas");
            multiCharSelectUI = FindInactiveObjectByName("CharacterSelectMultiCanvas");
            gameOverUI = FindInactiveObjectByName("EndPanelCanvas");
        }

        if (introUI == null) Debug.LogError("StartSceneCanvas not found");
        if (playUI == null) Debug.LogError("MainSceneCanvas not found");
        if (singleCharSelectUI == null) Debug.LogError("CharacterSelectSingleCanvas not found");
        if (multiCharSelectUI == null) Debug.LogError("CharacterSelectMultiCanvas not found");
        if (gameOverUI == null) Debug.LogError("EndPanelCanvas not found");
    }

    GameObject FindImmediateChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName) return child.gameObject;
        }
        return null;
    }

    GameObject FindInactiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform obj in objs)
        {
            if (obj.name == name) return obj.gameObject;
        }
        return null;
    }
}