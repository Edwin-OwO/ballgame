using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class playermovement : Mover
    {
        private Vector3 currentInput;
        private float originalSpeed;
        private bool isBoosting = false;
        private Coroutine currentBoost;

        public float speed = 5f; // Velocidad base del jugador

        private void Awake()
        {
            originalSpeed = speed;
        }

        private void Update()
        {
            // Movimiento tipo top-down (sin gravedad)
            transform.position += currentInput * speed * Time.deltaTime;
        }

        private void OnMove(InputValue value)
        {
            // Captura el input (X e Y) y lo guarda
            Vector2 input = value.Get<Vector2>();
            currentInput = new Vector3(input.x, input.y, 0);
        }

        internal void ActivateSpeedBoost(float boostMultiplier, float boostDuration)
        {
            // Si ya hay un boost activo, lo reinicia
            if (currentBoost != null)
                StopCoroutine(currentBoost);

            currentBoost = StartCoroutine(SpeedBoostCoroutine(boostMultiplier, boostDuration));
        }

        private IEnumerator SpeedBoostCoroutine(float boostMultiplier, float boostDuration)
        {
            isBoosting = true;
            speed = originalSpeed * boostMultiplier;

            yield return new WaitForSeconds(boostDuration);

            speed = originalSpeed;
            isBoosting = false;
            currentBoost = null;
        }
    }
}
