using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    /** 인트로 화면 시작 **/

    //StartSingleButton
    public void SingleModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.SinglePlayer;
        GameManager.Instance.SelectCharacterState();
    }

    //StartMultiButton
    public void MultiModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.MultiPlayer;
        GameManager.Instance.SelectCharacterState();
    }

    /** 인트로 화면 끝 **/




    /** 캐릭터 선택 화면 시작 **/

    //StartButton
    public void CharacterSelectSubmitButton()
    {
        //
        //GameObject SelectedCharacterPrefab1;
        //GameObject SelectedCharacterPrefab2;
        //GameManager.Instance.player1Prefab = SelectedCharacterPrefab1;
        //GameManager.Instance.player2Prefab = SelectedCharacterPrefab2;

        // TODO : 아직 난이도 선택 구현하지 않았으므로, 바로 게임 시작으로
        //GameManager.Instance.SelectDifficultyState();
        GameManager.Instance.GameStartState();
    }

    // CharacterButton
    // public GameObject CharacterPrefab; <- 인스펙터로 버튼별 캐릭터 프리팹 할당 또는 함수 매개변수로 캐릭터 프리팹
    public void CharacterSelectButton(GameObject CharacterPrefab)
    {
        //플레이어1 선택 버튼이면
        //SelectedCharacterPrefab1 = CharacterPrefab;

        //플레이어2 선택 버튼이면
        //SelectedCharacterPrefab2 = CharacterPrefab;
    }

    /** 캐릭터 선택 화면 끝 **/


    /** 게임 종료 화면 시작 **/

    // RetryButton
    public void RetryButton()
    {
        GameManager.Instance.RestartGame();
    }

    // 메인메뉴 버튼
    public void MainMenuButton()
    {
        GameManager.Instance.ResetGame();
    }

    /** 게임 종료 화면 끝 **/

}
