using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [Header("Blocks")]
    [SerializeField] Transform Traps;
    [SerializeField] GameObject SnakeBlock;
    [SerializeField] GameObject LadderBlock;
    [SerializeField] Color Red;
    [SerializeField] Color Green;
    [SerializeField] Material lineMat;
    [SerializeField] float lineWidth = 0.1f;

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
            Color lineColor = (t.isSnake) ? Red : Green;

            GameObject head = Instantiate(block, Traps.position, Quaternion.identity);
            GameObject tail = Instantiate(block, Traps.position, Quaternion.identity);

            LineRenderer line = head.AddComponent<LineRenderer>();
            DrawLine(line, lineColor, lineWidth, headPos, tailPos);

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

    void DrawLine(LineRenderer line, Color lineColor, float lineWidth, Vector3 headPos, Vector3 tailPos)
    {
        line.enabled = true;
        line.positionCount = 4;

        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.startColor = lineColor;
        line.endColor = lineColor;
        line.material = lineMat;

        float delx = headPos.x - tailPos.x;
        float sumZ = headPos.z + tailPos.z;

        float midZ = sumZ / 2;

        Vector3 point1 = new Vector3(headPos.x, 0.05f, midZ);
        Vector3 point2 = new Vector3(tailPos.x, 0.05f, midZ);

        line.SetPosition(0, headPos);
        line.SetPosition(1, point1);
        line.SetPosition(2, point2);
        line.SetPosition(3, tailPos);
    }

}
