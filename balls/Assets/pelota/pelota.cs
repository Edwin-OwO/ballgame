using UnityEngine;

public class pelota : MonoBehaviour
{
    [SerializeField] bool puedeSaltar = false;
    [SerializeField] bool MoverConFisica = false;
    [SerializeField] float velocity = 0.01f;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyRight;
    [SerializeField] KeyCode keyUp;
    [SerializeField] KeyCode keyDown;
    [SerializeField] float factorResize = 1;
    [SerializeField] manager manager;
    Rigidbody2D rb;
    bool Right; 
    bool Up;
    bool Down;
    bool Left;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (manager.Jugando)
        {
            Move();
        }
       
    }

    private void Move()
    {
        if (Input.GetKey(keyRight))
            Right = true;

        if (Input.GetKey(keyLeft))
            Left = true;

        // && puedeSaltar
        if (Input.GetKey(keyUp))
            Up = true;  

        if (Input.GetKey(keyDown))
            Down = true;
    }

    private void FixedUpdate()
    {
        if (Right)
            if (!MoverConFisica)
                transform.Translate(Vector2.right * velocity);
            else
                rb.AddForce(Vector2.right * velocity);
           Right = false;

        if (Left)
            if (!MoverConFisica)
                transform.Translate(Vector2.left * velocity);
            else
                rb.AddForce(Vector2.left * velocity);
            Left = false;

    
        
         if (Up)
            
        if (!MoverConFisica)
            {
               transform.Translate(Vector2.up * velocity);
            }
                
             else
                rb.AddForce(Vector2.up * velocity);
       

        Up = false;

        if (Down)
            if (!MoverConFisica)
                transform.Translate(Vector2.down * velocity);
            else
                rb.AddForce(Vector2.down * velocity);
            Down = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Se toco con" + collision.gameObject.name);
        puedeSaltar = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Se triggerio con" + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Se esta triggerio con" + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        puedeSaltar = true;
        Debug.Log("Se dejo de tocar con" + collision.gameObject.name);
    }

}
