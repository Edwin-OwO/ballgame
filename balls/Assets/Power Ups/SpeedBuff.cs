using TopDown.Movement;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<playermovement>();
        if (player != null)
        {
            player.ActivateSpeedBoost(boostMultiplier, boostDuration);
            Destroy(gameObject); // Opcional: eliminar el buff tras recogerlo
        }
    }
}

