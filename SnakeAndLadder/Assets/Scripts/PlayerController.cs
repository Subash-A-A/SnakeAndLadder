using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static int score = 0;
    private float xpos = 0f;
    private float zpos = 0f;

    public static bool PlayerTurn = true;
    [SerializeField] DiceManager dm;
    [SerializeField] UIManager um;

    private void Update()
    {
        Move();
        PosLerper();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerTurn && !BoardScoreManager.gameOver)
        {
            int rand = dm.RollDice();
            dm.SetDiceValue(rand + "");

            Debug.Log(rand);

            int temp = score + rand;

            if (temp <= 99)
            {
                for (int i = 0; i < rand; i++)
                {
                    int n = score / 10;
                    if ((score + 1) % 10 == 0)
                    {
                        zpos += 1;
                    }
                    else if (n % 2 == 0)
                    {
                        xpos += 1;
                    }
                    else if (n % 2 != 0)
                    {
                        xpos -= 1;
                    }
                    score += 1;
                }
            }
            StartCoroutine(TurnChange());
        }
    }

    void MoveToTailHead(int pos)
    {
        xpos = 0;
        zpos = 0;
        score = 0;
        for (int i = 0; i < pos; i++)
        {
            int n = score / 10;
            if ((score + 1) % 10 == 0)
            {
                zpos += 1;
            }
            else if (n % 2 == 0)
            {
                xpos += 1;
            }
            else if (n % 2 != 0)
            {
                xpos -= 1;
            }
            score += 1;
        }
    }

    void PosLerper()
    {
        Vector3 pos = new Vector3(xpos, 0.25f, zpos);
        transform.position = Vector3.Lerp(transform.position, pos, 5 * Time.deltaTime);
    }

    IEnumerator TurnChange()
    {
        PlayerTurn = false;
        StartCoroutine(PlayerOnSnakeLadder());

        yield return new WaitForSeconds(1f);

        um.SetTurnText("CPU Turn");
        dm.SetDiceValue("Rolling...");

        yield return new WaitForSeconds(1f);

        CPUController.CPUturn = true;

        yield return new WaitForSeconds(1f);

        um.SetTurnText("Player Turn");
        dm.SetDiceValue("Rolling...");

        PlayerTurn = true;
    }

    IEnumerator PlayerOnSnakeLadder()
    {
        yield return new WaitForSeconds(1f);
        int head_tailPos = TrapCollision.CheckSnakeLadder(true);
        if (head_tailPos != -1)
        {
            MoveToTailHead(head_tailPos - 1);
        }
    }
}
