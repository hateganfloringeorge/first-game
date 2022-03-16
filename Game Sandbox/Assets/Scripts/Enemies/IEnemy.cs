namespace Assets.Scripts.Enemies
{
    public interface IEnemy
    {
        public void TakeDamage(int damage);
        public void Die();
    }
}