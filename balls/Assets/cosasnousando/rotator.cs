using UnityEngine;

namespace TopDown.Movement
{
    public class rotator : MonoBehaviour
    {
        protected void LookAt(Vector3 target)
        {
            float LookAngle = AngleBetweenTwoPoints(transform.position, target) + 180;

            // asignar el objetivo de la rotacion en z
            transform.eulerAngles = new Vector3(0, 0, LookAngle);

        }


        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

    }
}