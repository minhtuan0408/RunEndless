using UnityEngine;

public class CircularShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab đạn
    public int bulletCount = 1;     // Số viên đạn trong vòng tròn
    public float bulletSpeed = 1f;   // Tốc độ đạn
    public float fireRate = 1f;      // Thời gian giữa các lần bắn

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                ShootCircle();
            }
        }
    }

    void ShootCircle()
    {
        float angleStep = 360f / bulletCount;  // Góc giữa các viên đạn
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector2 bulletDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bulletDirection * bulletSpeed;

            angle += angleStep;
        }
    }
}
