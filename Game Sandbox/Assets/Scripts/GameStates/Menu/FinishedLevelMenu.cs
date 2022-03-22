using TMPro;
using UnityEngine;

public class FinishedLevelMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public TextMeshProUGUI ScoreBoardText;
    public ScoreBoard scoreBoard;

    private const string scoreBoardText = "Total score: ";
    private const int mainMenuIndex = 0;

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
        gameObject.SetActive(newGameState == GameState.FinishedLevel);
    }

    private void OnEnable()
    {
        Debug.Log("Now it is visible");
        Debug.Log($"Score is {scoreBoard.scoreNumber}");
        ScoreBoardText.text = scoreBoardText + scoreBoard.scoreNumber;
    }

    public void ChangeToMainMenu()
    {
        Debug.Log("Loading Main Menu");
        levelLoader.LoadLevelByIndex(mainMenuIndex);
        GameStateManager.GetInstance.SetState(GameState.Gameplay);
    }

    public void TransitionToNextLevel()
    {
        Debug.Log("Loading next level");
        levelLoader.LoadNextLevel();
        GameStateManager.GetInstance.SetState(GameState.Gameplay);
    }

    public void ReplayLevel()
    {
        Debug.Log("Replay level");
        levelLoader.ReplayCurrentLevel();
        GameStateManager.GetInstance.SetState(GameState.Gameplay);
    }
}
