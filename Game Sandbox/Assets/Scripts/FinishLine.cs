using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCharacter"))
        {
            Debug.Log("Level is now finised!");
            GameStateManager.GetInstance.SetState(GameState.FinishedLevel);
        }
    }
}
