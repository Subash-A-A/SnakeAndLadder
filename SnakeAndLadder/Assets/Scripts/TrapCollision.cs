using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    private static TrapManager tm;

    private void Start()
    {
        tm = FindObjectOfType<TrapManager>();
    }

    public static int CheckSnake(bool isPlayer)
    {
        foreach (Trap t in tm.trapList)
        {
            if (t.isSnake)
            {
                if (PlayerTilePosition() == t.head && isPlayer)
                {
                    return t.tail;
                }
                if (CPUTilePosition() == t.head && !isPlayer)
                {
                    return t.tail;
                }
            }
        }
        return -1;
    }

    static int PlayerTilePosition()
    {
        return PlayerController.score + 1;
    }
    static int CPUTilePosition()
    {
        return CPUController.score + 1;
    }
}
