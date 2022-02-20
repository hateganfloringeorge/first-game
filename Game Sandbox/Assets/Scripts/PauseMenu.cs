using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private const string mainMenuSceneName = "MainMenu";
    private const string gameScene1Name = "Level_1";
    private const string gameScene2Name = "SampleScene";
    public bool IsGamePaused = false;

    public void Resume()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
        SceneManager.LoadScene(gameScene1Name);
    }

    public void ChangeToMainMenu()
    {
        Debug.Log("Loading Main Menu");
        IsGamePaused = false;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Change to Second game");
        GameStateManager.GetInstance.SetState(GameState.Gameplay);
        Time.timeScale = 1f;
        Debug.Log(GameStateManager.GetInstance.CurrentGameState);
        SceneManager.LoadScene(gameScene2Name);
    }
}
