using UnityEngine;

public class CPUController : MonoBehaviour
{
    private int currentPos = 0;
    public static int score = 0;
    private float xpos = 0f;
    private float zpos = 0f;
    public static bool CPUturn = false;

    private void Update()
    {
        Move();
        PosLerper();
    }

    int RollDice()
    {
        return Random.Range(1, 7);
    }

    void Move()
    {
        if (CPUturn && !BoardScoreManager.gameOver)
        {
            int rand = RollDice();
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
                        currentPos += 1;
                    }
                    else if (n % 2 != 0)
                    {
                        currentPos -= 1;
                    }
                    score += 1;
                }
            }
            CPUturn = false;
        }
    }

    void PosLerper()
    {
        Vector3 pos = new Vector3(xpos + currentPos, 0.25f, zpos);
        transform.position = Vector3.Lerp(transform.position, pos, 10 * Time.deltaTime);
    }
}
