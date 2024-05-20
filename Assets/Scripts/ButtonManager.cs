using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttons;
    private List<Button> selectedButtons = new List<Button>();
    private int maxSelectedButtons = 2;

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button clickedbutton)
    {
        if (selectedButtons.Contains(clickedbutton))
        {
            int index = selectedButtons.IndexOf(clickedbutton);
            selectedButtons.Remove(clickedbutton);
            clickedbutton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            if(selectedButtons.Count < maxSelectedButtons)
            {
                selectedButtons.Add(clickedbutton);
                UpdateButtonColors();
            }
        }
        Debug.Log("Selected Buttons: " + selectedButtons.Count);
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < selectedButtons.Count; i++)
        {
            if (i == 0)
            {
                selectedButtons[i].GetComponent<Image>().color = Color.red;
            }
            else if (i == 1)
            {
                selectedButtons[i].GetComponent <Image>().color = Color.green;
            }
        }
    }
}

