using UnityEngine;

public class balldamage : MonoBehaviour
{
    public int damage = 10;
    public float minVelocityToDamage = 0.1f;
    public bool ATTACK;

    private Collider2D triggerCollider;
    private Rigidbody2D parentRb;

    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        if (triggerCollider == null || !triggerCollider.isTrigger)
        {
            Debug.LogError("Este script requiere un Collider2D con isTrigger = true");
        }

        parentRb = transform.parent.GetComponent<Rigidbody2D>();
        if (parentRb == null)
        {
            Debug.LogError("El objeto padre necesita un Rigidbody2D para detectar movimiento por físicas.");
        }
    }

    void Update()
    {

        if (parentRb.linearVelocity.magnitude > minVelocityToDamage)
        {
            ATTACK = true;
        }
        else
        {
            ATTACK = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ATTACK == true)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                var enemy = other.GetComponent<enemyfollow>();
                enemy.takedamage(damage, gameObject); 
                
            }
        }
       
      
    }
}

