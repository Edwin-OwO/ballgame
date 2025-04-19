using System.Collections;
using UnityEngine;

public class pelota : MonoBehaviour
{
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;


    [SerializeField] bool puedeSaltar = false;
    [SerializeField] bool MoverConFisica = false;
    [SerializeField] float moveSpeed = 0.01f;
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
        
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    public void Update()
    {
        if (manager.Jugando)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }
            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }

            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
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
                transform.Translate(Vector2.right * activeMoveSpeed);
            else
                rb.AddForce(Vector2.right * activeMoveSpeed);
           Right = false;

        if (Left)
            if (!MoverConFisica)
                transform.Translate(Vector2.left * activeMoveSpeed);
            else
                rb.AddForce(Vector2.left * activeMoveSpeed);
            Left = false;

    
        
         if (Up)
            
        if (!MoverConFisica)
            {
               transform.Translate(Vector2.up * activeMoveSpeed);
            }
                
             else
                rb.AddForce(Vector2.up * activeMoveSpeed);
       

        Up = false;

        if (Down)
            if (!MoverConFisica)
                transform.Translate(Vector2.down * activeMoveSpeed);
            else
                rb.AddForce(Vector2.down * activeMoveSpeed);
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
