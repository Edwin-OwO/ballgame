using UnityEngine;

public class ballrecall : MonoBehaviour
{
    public Transform player;
    public float recallSpeed = 5f;
    public float recallDuration = 1.5f; // Cuánto tiempo dura el movimiento hacia el jugador
    public float cooldownTime = 3f;     // Tiempo de enfriamiento
    public KeyCode recallKey = KeyCode.Mouse1;

    private Rigidbody2D rb;
    private bool isRecalling = false;
    private bool isOnCooldown = false;
    private float recallTimer = 0f;
    private float cooldownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
            else
            {
                Debug.LogError("Jugador no asignado y no se encontró uno con tag 'Player'");
            }
        }
    }

    void Update()
    {
        // Iniciar la atracción si se presiona la tecla y no está en cooldown
        if (Input.GetKeyDown(recallKey) && !isOnCooldown)
        {
            isRecalling = true;
            recallTimer = recallDuration;
            isOnCooldown = true;
            cooldownTimer = cooldownTime;
        }

        // Manejar temporizadores
        if (isRecalling)
        {
            recallTimer -= Time.deltaTime;
            if (recallTimer <= 0f)
            {
                isRecalling = false;
            }
        }

        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                isOnCooldown = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isRecalling && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * recallSpeed;
        }
    }
}
