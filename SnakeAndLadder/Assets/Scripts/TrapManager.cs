using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [Header("Blocks")]
    [SerializeField] Transform Traps;
    [SerializeField] GameObject SnakeBlock;
    [SerializeField] GameObject LadderBlock;

    [Header("Trap/Ladder Locations")]
    public Trap[] trapList;

    private void Start()
    {
        InitializeSnakeAndLadder();
    }

    void InitializeSnakeAndLadder()
    {
        foreach (Trap t in trapList)
        {
            Vector3 headPos = MoveBlocks(t.head);
            Vector3 tailPos = MoveBlocks(t.tail);
            GameObject block = (t.isSnake) ? SnakeBlock : LadderBlock;

            GameObject head = Instantiate(block, Traps.position, Quaternion.identity);
            GameObject tail = Instantiate(block, Traps.position, Quaternion.identity);

            head.transform.position = headPos;
            tail.transform.position = tailPos;
        }
    }

    Vector3 MoveBlocks(int pos)
    {
        int xpos = 0;
        int zpos = 0;
        int score = 0;
        for (int i = 0; i < pos - 1; i++)
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
        Vector3 blockPos = new Vector3(xpos, 0f, zpos);
        return blockPos;
    }
}
