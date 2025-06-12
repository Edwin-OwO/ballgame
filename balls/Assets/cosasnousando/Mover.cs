using UnityEngine;

namespace TopDown.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float movementspeed;
        private Rigidbody2D body;
        protected Vector3 currentInput;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.linearVelocity = movementspeed * currentInput * Time.fixedDeltaTime;
        }






    }
}

