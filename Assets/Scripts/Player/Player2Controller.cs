public class Player2Controller : PlayerInputController
{
    GameManager gameManager;

    public Player2Controller()
    {

    }

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void OnPlayer2()
    {
        if (gameManager.player2Prefab)
        {

        }
    }
}