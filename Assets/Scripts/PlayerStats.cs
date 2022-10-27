using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int euro;
    public int startEuro = 25;

    public static int Lives;
    public int startLives = 9;

    void Start()
    {
        euro = startEuro;

        Lives = startLives;
    }
}
