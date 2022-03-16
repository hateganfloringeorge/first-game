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
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
