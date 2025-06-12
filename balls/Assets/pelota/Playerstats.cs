using UnityEngine;
using System.Collections;
public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float damageCooldown = 0.5f; // Tiempo de invulnerabilidad en segundos
    [SerializeField] private float currentHealth;
    private Collider2D playerCollider;
    private bool isInvulnerable = false;

    public Newvidamanager healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setslidermax(maxHealth);
        playerCollider = GetComponent<Collider2D>();

        if (playerCollider == null)
        {
            Debug.LogError("Playerstats requiere un Collider2D en el mismo GameObject.");
        }
    }

    public void takedamage(float amount)
    {
        if (isInvulnerable) return;

        currentHealth -= amount;
        healthbar.setslider(currentHealth);

        StartCoroutine(DamageCooldown());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Opcional: animación de muerte, sonido, etc.
        GameManager.instance.PlayerDied();

        // Destruir al jugador
        Destroy(gameObject);
    }

    private IEnumerator DamageCooldown()
    {
        isInvulnerable = true;

        if (playerCollider != null)
            playerCollider.enabled = false;

        yield return new WaitForSeconds(damageCooldown);

        if (playerCollider != null)
            playerCollider.enabled = true;

        isInvulnerable = false;
    }
}
