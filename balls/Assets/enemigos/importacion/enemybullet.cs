using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Se autodestruye después de un tiempo
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Playerstats playerStats = other.GetComponent<Playerstats>();
            if (playerStats != null)
            {
                playerStats.takedamage(damage);
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("paredes"))
            Destroy(gameObject);
      
    }
}
