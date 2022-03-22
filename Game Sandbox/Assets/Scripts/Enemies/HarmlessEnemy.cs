using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class HarmlessEnemy : Enemy
    {
        public HealthBar healthBar;

        private void Start()
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        public override void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth, maxHealth);

            if (currentHealth <= 0)
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