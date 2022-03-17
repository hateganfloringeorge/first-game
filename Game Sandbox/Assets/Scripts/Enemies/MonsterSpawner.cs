using UnityEngine;

public class MonsterSpawner : Enemy
{
    public int scoreDecreaseAmount = 100;

    public GameObject enemy;

    public void StartCurse()
    {
        score.AddScore(-scoreDecreaseAmount);
        Instantiate(enemy, transform.position + new Vector3(5f, 5f), Quaternion.identity);
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Start curse");
        StartCurse();
    }

    public override void Die()
    {
        //TODO add destroy if needed
        throw new System.NotImplementedException();
    }
}
