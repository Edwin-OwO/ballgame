using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyfollow2 : MonoBehaviour
{
    public int damage;
    private Transform Target;
    [SerializeField] public float speed;
    private Vector3 originalScale;               
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Playerstats>().takedamage(damage);
        }
    }
    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

        }
    }
        

    
}
