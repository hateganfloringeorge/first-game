using Assets.Scripts.Enemies;
using UnityEngine;

public class WaveFrontBullet : Bullet
{
    public WaveFrontBullet()
    {
        speed = 40f;
        damage = 10;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        
        //TODO add switch
        HarmlessEnemy enemy = hitInfo.GetComponent<HarmlessEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        EnemyAI enemyAI = hitInfo.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.TakeDamage(damage);
        }

        MonsterSpawner curse = hitInfo.GetComponent<MonsterSpawner>();
        if (curse != null)
        {
            Debug.Log("Curse");
            curse.StartCurse();
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
