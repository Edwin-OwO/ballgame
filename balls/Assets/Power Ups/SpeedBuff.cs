using TopDown.Movement;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float boostMultiplier = 2f;       // Cuánto aumenta la velocidad
    public float boostDuration = 3f;         // Cuánto dura el boost

    private void OnTriggerEnter(Collider other)
    {
        playermovement player = other.GetComponent<playermovement>();
        if (player != null)
        {
            player.ActivateSpeedBoost(boostMultiplier, boostDuration);
            Destroy(gameObject); // Elimina el power-up después de agarrarlo
        }
    }
}
