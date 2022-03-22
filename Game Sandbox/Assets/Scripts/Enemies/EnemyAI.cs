using Pathfinding;
using UnityEngine;

public class EnemyAI : Enemy
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 1.2f;

    Path path;
    int currentWayPoint = 0;

    public Transform EnemyGFX;

    Seeker seeker;
    Rigidbody2D rb;
    public HealthBar healthBar;

    // Start is called before the first frame update
    private new void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
        healthBar.SetHealth(currentHealth, maxHealth);

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = speed * Time.deltaTime * direction;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        if (force.x >= 0.01f)
        {
            EnemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            EnemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnBecameVisible()
    {
        rb.isKinematic = false;
    }

    public override void TakeDamage(int damage)
    {
        if (damage > 10)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth, maxHealth);
        }

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
