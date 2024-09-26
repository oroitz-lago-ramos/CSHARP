using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("Map");
        Debug.Log("New Game Pressed");

    }

    public void LoadGameButton()
    {
        SceneManager.LoadScene("Map");
        Debug.Log("Load Game Pressed");

    }
}
