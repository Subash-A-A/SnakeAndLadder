using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text turnText;

    private void Update()
    {
        if (BoardScoreManager.gameOver)
        {
            if (BoardScoreManager.playerWon)
            {
                SetTurnText("Player Won!");
            }
            else
            {
                SetTurnText("CPU Won!");
            }
        }
    }

    public void SetTurnText(string s)
    {
        turnText.text = s;
    }

}
