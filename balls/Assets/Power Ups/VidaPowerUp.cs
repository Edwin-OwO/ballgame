using UnityEngine;

public class VidaPowerUp : MonoBehaviour

{
    [SerializeField] private float healAmount = 20f; // Cu�nta vida cura

    private void OnTriggerEnter2D(Collider2D other)
    {
        Playerstats player = other.GetComponent<Playerstats>();

        if (player != null)
        {
            player.Heal(healAmount);     // Llama al m�todo Heal del jugador
            Destroy(gameObject);         // Destruye el power-up
        }
    }
}

