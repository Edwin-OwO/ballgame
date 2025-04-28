using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Movement
{
    public class PlayerR : rotator
    {

        private void OnLook(InputValue value)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
            LookAt(mousePosition);
        }



    }

}
