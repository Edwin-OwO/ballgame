using UnityEngine;
using UnityEngine.UI;

public class Vidamanager : MonoBehaviour
{

    [SerializeField] public Image healthbar;
    [SerializeField] public float healthamount = 100f;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (healthamount <= 0)
        {
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Heal(5);
        }
    }

    public void TakeDamage (float damage)
    {
        healthamount -= damage;
        healthbar.fillAmount = healthamount / 100f;
    }

    public void Heal (float healingamount)
    {
        healthamount += healingamount;
        healthamount = Mathf.Clamp(healthamount, 0, 100);
        healthbar.fillAmount = healthamount / 100f;
    }
}
