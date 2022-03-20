using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject finishedLevel;
    public bool isScreenActive = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.GetInstance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;

            GameStateManager.GetInstance.SetState(newGameState);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isScreenActive = !isScreenActive;
            finishedLevel.SetActive(isScreenActive);
        }
    }
}
