
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager _instance;

    private GameStateManager()
    {
             
    }

    public static GameStateManager GetInstance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
    }


    public GameState CurrentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
        Debug.Log("New state " + CurrentGameState);
        Debug.Log("Time movement " + Time.timeScale);
    }
}

