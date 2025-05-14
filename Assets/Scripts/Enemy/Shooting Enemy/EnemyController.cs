using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float moveSpeed = 2f;
    public int maxHealth = 3;
    public bool canShoot = false;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;

    private int currentHealth;
    private float shootTimer;

    [Header("Coin Drop")]
    public GameObject coinPrefab;
    [Range(0f, 1f)]
    public float coinDropChance = 0.3f;


    void Start()
    {
        currentHealth = maxHealth;
        shootTimer = shootInterval;
    }

    void Update()
    {
        Move();

        if (canShoot)
        {
            HandleShooting();
        }
    }

    void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    void HandleShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Rơi xu nếu trúng xác suất
        if (coinPrefab != null && Random.value < coinDropChance)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Va Chạm");
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            print("va chạm trừ máu");

        }
    }
}
