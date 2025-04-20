using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    private Transform Target;
    public float speed;
    public float health;
    public GameObject bloodEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        if (health <= 0 )
        {
            Destroy (gameObject);
        }
    }


    public void takedamage(int damage)
    {
        Instantiate (bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage taken");

    }

    //private void OnTriggerEnter2D(Collider2D collision) {if (collision.gameObject.tag == "Player"){Debug.Log("tocando");}}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Playerstats>().takedamage(10f);
            Destroy(gameObject);
        }
    }
}
