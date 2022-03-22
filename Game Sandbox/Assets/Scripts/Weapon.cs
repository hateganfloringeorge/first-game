using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;

    public int triggerCount = 4;
    public float shootingCooldown = 5.0f;
    private int bulletCount;
    private bool isShootingCooldown;

    private void Start()
    {
        bulletCount = 0;
        isShootingCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isShootingCooldown)
            {
                bulletCount += 1;

                if (bulletCount == triggerCount)
                {
                    isShootingCooldown = true;
                    ShotSpecialBullet();
                    bulletCount = 0;
                    Invoke(nameof(EnableShooting), shootingCooldown);
                }
                else
                {
                    ShootNormalBullet();
                }
            }
        }
    }

    void ShootNormalBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShotSpecialBullet()
    {
        Instantiate(specialBulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void EnableShooting()
    {
        isShootingCooldown = false;
    }
}
