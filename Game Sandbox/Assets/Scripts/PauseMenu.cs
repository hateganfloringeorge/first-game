using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private const string mainMenuSceneName = "MainMenu";

    public static bool IsGamePaused = false;

    private void Awake()
    {
        GameStateManager.GetInstance.OnGameStateChanged += OnGameStateChanged;

        OnGameStateChanged(GameStateManager.GetInstance.CurrentGameState);
    }

    private void OnDestroy()
    {
        GameStateManager.GetInstance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Paused);
    }

    //TODO Update when they are inside the playing game
    public void Resume()
    {
        Debug.Log("Resume");
        GameStateManager.GetInstance.SetState(GameState.Gameplay);
    }

    public void ChangeToMainMenu()
    {
        Debug.Log("Loading Main Menu");
        IsGamePaused = false;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
}
