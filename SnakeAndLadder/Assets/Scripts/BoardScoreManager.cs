using UnityEngine;


public class BoardScoreManager : MonoBehaviour
{
    private int PlayerScore;
    private int CPUScore;
    public static bool gameOver = false;

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
                Debug.Log("Player Won!");
            }
            else
            {
                Debug.Log("CPU Won!");
            }
        }
    }


}
