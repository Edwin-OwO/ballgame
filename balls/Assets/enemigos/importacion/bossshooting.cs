using UnityEngine;

public class bossshooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // Punto de disparo (creá un GameObject hijo en la punta del arma o centro)
    public float fireRate = 2f;
    public float projectileSpeed = 10f;
    public float detectionRange = 10f;

    private Transform player;
    private float fireTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        fireTimer = fireRate;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            fireTimer -= Time.deltaTime;

            Vector2 direction = (player.position - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);

            if (fireTimer <= 0f)
            {
                Shoot(direction);
                fireTimer = fireRate;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }
}
