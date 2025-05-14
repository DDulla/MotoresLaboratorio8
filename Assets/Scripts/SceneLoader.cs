using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame1()
    {
        SceneManager.LoadScene("Game1");
    }
    public void LoadGame2()
    {
        SceneManager.LoadScene("Game2");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}