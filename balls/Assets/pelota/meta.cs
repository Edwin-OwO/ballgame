using UnityEngine;

public class meta : MonoBehaviour
{

    private bool alcanzoMeta = false;
    
    public bool AlcanzoMeta
    {
        get { return alcanzoMeta;  }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            alcanzoMeta=true;   
        }
    }
}
