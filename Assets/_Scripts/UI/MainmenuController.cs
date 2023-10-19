using UnityEngine;
using UnityEngine.SceneManagement;

// This monobehaviour is responsible for handling Scene navigation, settings adjustment and quitting the game.
public class MainmenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(StringData.GameSceneName);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void EnterSettingsMenu()
    {
        //I plan on adding a semi-functional settings menu later down the line. For now it will be deactivated.
        Debug.Log("Settings menu is under construction.");
    }
}