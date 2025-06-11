using UnityEngine;

public class balldamaged : MonoBehaviour
{
    public int damageTaken = 10;

    void OnTriggerEnter2D(Collider2D ball)
    {
        Debug.Log("estoestabien");
        GetComponent<enemyfollow>().takedamage(damageTaken, transform.parent.gameObject);
        balldamage dealer = ball.GetComponent<balldamage>();
        //if (dealer != null && dealer.IsMoving())
        {
            // El objeto atacante se está moviendo, aplicar daño
            GetComponent<enemyfollow>().takedamage(damageTaken, dealer.transform.parent.gameObject);
        }
    }
}
