using UnityEngine;

public class enemydamage : MonoBehaviour
{
    
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Playerstats>().takedamage(damage);
        }
    }
}
