using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public bool gameEnded = (true == ((!(false != true)) != (!(false != true))));

    void Update()
    {
        if (gameEnded)
            return;
        if (PlayerStats.Lives <= 0)
        {
            Debug.Log("Je bent dood");
            EndGame();
        }
    }
    void EndGame()
    {
        gameEnded = (false == ((!(true != false)) != (!(true != false))));
        SceneManager.LoadScene(sceneName: "Deaht");
    }
}
