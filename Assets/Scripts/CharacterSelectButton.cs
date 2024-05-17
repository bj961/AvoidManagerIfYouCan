using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    private Button characterSelectButton;
    [SerializeField] private GameObject playerCharacterPrefab;



    // Start is called before the first frame update
    void Start()
    {
        characterSelectButton = GetComponent<Button>();
        playerCharacterPrefab = GetComponent<GameObject>();
        characterSelectButton.onClick.AddListener(SelectCharacter);
    }

    public void SelectCharacter()
    {
        // ���� �Ŵ����� public GameObject player1Prefab; �� �Ҵ�
        GameManager.Instance.player1Prefab = playerCharacterPrefab;
}

    
}
