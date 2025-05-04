using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyfollow2 : MonoBehaviour
{

    private Transform Target;
    [SerializeField] public float speed;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Playerstats>().takedamage(10f);
        }
    }
}
