using UnityEngine;

public class PauseController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.GetInstance.CurrentGameState;
            if (currentGameState == GameState.FinishedLevel)
            {
                GameState newGameState = currentGameState == GameState.Gameplay
                    ? GameState.Paused
                    : GameState.Gameplay;

                GameStateManager.GetInstance.SetState(newGameState);
            }
        }
    }
}
