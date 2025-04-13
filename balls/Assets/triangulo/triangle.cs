using UnityEngine;

public class triangle : MonoBehaviour
{
    [SerializeField] float velocity = 0.01f;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyRight;
    [SerializeField] KeyCode keyUp;
    [SerializeField] KeyCode keyDown;
    [SerializeField] float factorResize = 1;

    private void Update()
    {
        Move();
        Shoot();
        RotateToMouse();
       
    }

    private void Move()
    {
        if (Input.GetKey(keyRight))
            transform.Translate(Vector2.right * velocity);

        if (Input.GetKey(keyLeft))
            transform.Translate(Vector2.left * velocity);

        if (Input.GetKey(keyUp))
            transform.Translate(Vector2.up * velocity);

        if (Input.GetKey(keyDown))
            transform.Translate(Vector2.down * velocity);
    }

    void RotateToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Mantener la misma profundidad en 2D

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale = new Vector2(transform.localScale.x + factorResize, transform.localScale.y + factorResize);
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.localScale = new Vector2(transform.localScale.x - factorResize, transform.localScale.y - factorResize);
        }
    }
}
