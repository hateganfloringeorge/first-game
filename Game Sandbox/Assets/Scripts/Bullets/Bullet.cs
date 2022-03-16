using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    public void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
