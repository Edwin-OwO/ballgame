using UnityEngine;
using UnityEngine.Events;

public class pinballstats : MonoBehaviour
{
    public GameObject bloodEffect;
    public UnityEvent<GameObject> OnHit, OnDeath;
    [SerializeField] public bool dead = false;
    [SerializeField] private float maxh, health;


    public void starthealth(int healthV)
    {
        health = healthV;
        maxh = healthV;
        dead = false;
    }



    public void takedamage(int damage, GameObject sender)
    {
        if (dead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        health -= damage;
        Debug.Log("Damage taken");

        if (health > 0)
        {
            OnHit?.Invoke(sender);
            Debug.Log("llegamos aca");

        }
        else
        {
            OnDeath?.Invoke(sender);
            dead = true;
            Destroy(gameObject);
        }

    }

}
