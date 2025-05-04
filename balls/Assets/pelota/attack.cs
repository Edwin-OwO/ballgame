using UnityEngine;

public class attack : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float cooldown;
    public float start;
    public Transform pos;
    public float range;
    public LayerMask whatisenemy;
    public int damage;

    void Update()
    {
        if (cooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(pos.position, range, whatisenemy);
                for (int i = 0; i < enemiestodamage.Length; i++) 
                {
                    enemiestodamage[i].GetComponent<enemyfollow>().takedamage(damage,transform.parent.gameObject);


                }
                cooldown = start;

            }
            
        }

        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, range);
    }

}
