using TopDown.Movement;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float boostMultiplier = 2f;       // Cu�nto aumenta la velocidad
    public float boostDuration = 3f;         // Cu�nto dura el boost

    private void OnTriggerEnter(Collider other)
    {
        playermovement player = other.GetComponent<playermovement>();
        if (player != null)
        {
            player.ActivateSpeedBoost(boostMultiplier, boostDuration);
            Destroy(gameObject); // Elimina el power-up despu�s de agarrarlo
        }
    }
}
