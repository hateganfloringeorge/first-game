using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class HarmlessEnemy : Enemy
    {

        public HarmlessEnemy()
        {
            health = 20;
            killScore = 3;
        }

        public override void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }

        public override void Die()
        {
            score.AddScore(killScore);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}