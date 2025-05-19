using UnityEngine;

public class Flecha : MonoBehaviour
{
    public GameObject flecha;
    private Transform jugador;

    void Start()
    {
        flecha.SetActive(false);
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector2 direccion = jugador.position - flecha.transform.position;
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            flecha.transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.transform;
            flecha.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = null;
            flecha.SetActive(false);
        }
    }






}
