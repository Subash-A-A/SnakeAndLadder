using UnityEngine;


public class BoardScoreManager : MonoBehaviour
{
    private int PlayerScore;
    private int CPUScore;
    public static bool gameOver;
    public static bool playerWon;
    public static bool cpuWon;

    private void Start()
    {
        gameOver = false;
        playerWon = false;
        cpuWon = false;
    }

    private void Update()
    {
        PlayerScore = PlayerController.score + 1;
        CPUScore = CPUController.score + 1;

        if (PlayerScore == 100 || CPUScore == 100)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            if (PlayerScore == 100)
            {
                playerWon = true;
                Debug.Log("Player Won!");
            }
            else
            {
                cpuWon = true;
                Debug.Log("CPU Won!");
            }
        }
    }


}
