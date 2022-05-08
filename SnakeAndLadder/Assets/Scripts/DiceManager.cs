using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public Text diceStatus;

    public int RollDice()
    {
        return Random.Range(1, 7);
    }

    public void SetDiceValue(string val)
    {
        if (!BoardScoreManager.gameOver)
        {
            diceStatus.text = val;
        }
        else
        {
            diceStatus.text = "...";
        }
    }
}
