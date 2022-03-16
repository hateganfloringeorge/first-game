using Assets.Scripts.Enemies;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public int killScore;
    public int health;
    public GameObject deathEffect;
    public static ScoreBoard score;

    public void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
    }

    public abstract void TakeDamage(int damage);
    public abstract void Die();
}
