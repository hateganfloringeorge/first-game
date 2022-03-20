using TMPro;
using UnityEngine;

public class FinishedLevelMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public TextMeshProUGUI ScoreBoardText;
    public ScoreBoard scoreBoard;

    private const string scoreBoardText = "Total score: ";
    private const int mainMenuIndex = 0;

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
    }

    public void TransitionToNextLevel()
    {
        Debug.Log("Loading next level");
        levelLoader.LoadNextLevel();
    }

    public void ReplayLevel()
    {
        Debug.Log("Replay level");
        levelLoader.ReplayCurrentLevel();
    }
}
