using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text turnText;

    private void Update()
    {
        if (BoardScoreManager.gameOver)
        {
            if (BoardScoreManager.playerWon)
            {
                turnText.text = "Player Won!";
            }
            else
            {
                turnText.text = "CPU Won!";
            }
        }
        else if (PlayerController.PlayerTurn && !CPUController.CPUturn)
        {
            turnText.text = "Player Turn";
        }
        else if (!CPUController.CPUturn && !PlayerController.PlayerTurn)
        {
            turnText.text = "CPU Turn";
        }
        else
        {
            turnText.text = "CPU Turn";
        }
    }

}
