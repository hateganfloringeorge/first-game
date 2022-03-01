using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    ScoreBoard score;
    int scoreDecreaseAmount = 100;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
    }

    public void StartCurse()
    {
        score.AddScore(-scoreDecreaseAmount);
        Instantiate(enemy, transform.position + new Vector3(5f, 5f), Quaternion.identity);
    }
}
