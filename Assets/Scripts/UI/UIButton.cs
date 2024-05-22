using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    /** ��Ʈ�� ȭ�� ���� **/

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

    /** ��Ʈ�� ȭ�� �� **/




    /** ĳ���� ���� ȭ�� ���� **/

    //StartButton
    public void CharacterSelectSubmitButton()
    {
        //
        //GameObject SelectedCharacterPrefab1;
        //GameObject SelectedCharacterPrefab2;
        //GameManager.Instance.player1Prefab = SelectedCharacterPrefab1;
        //GameManager.Instance.player2Prefab = SelectedCharacterPrefab2;

        // TODO : ���� ���̵� ���� �������� �ʾ����Ƿ�, �ٷ� ���� ��������
        //GameManager.Instance.SelectDifficultyState();
        GameManager.Instance.GameStartState();
    }

    // CharacterButton
    // public GameObject CharacterPrefab; <- �ν����ͷ� ��ư�� ĳ���� ������ �Ҵ� �Ǵ� �Լ� �Ű������� ĳ���� ������
    public void CharacterSelectButton(GameObject CharacterPrefab)
    {
        //�÷��̾�1 ���� ��ư�̸�
        //SelectedCharacterPrefab1 = CharacterPrefab;

        //�÷��̾�2 ���� ��ư�̸�
        //SelectedCharacterPrefab2 = CharacterPrefab;
    }

    /** ĳ���� ���� ȭ�� �� **/


    /** ���� ���� ȭ�� ���� **/

    // RetryButton
    public void RetryButton()
    {
        GameManager.Instance.RestartGame();
    }

    // ���θ޴� ��ư
    public void MainMenuButton()
    {
        GameManager.Instance.ResetGame();
    }

    /** ���� ���� ȭ�� �� **/

}
