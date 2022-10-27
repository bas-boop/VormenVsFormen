using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject levels;
    
    public void LevelsButton()
    {
        //SceneManager.LoadScene("Test-level");
        
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Test-level");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Test-level");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Test-level");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Test-level");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Test-level");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Test-level");
    }
    
    public void SettingsButton()
    {
        Debug.Log("Settings");
    }
    public void BackButton()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Bye bye gamer");
    }
}
