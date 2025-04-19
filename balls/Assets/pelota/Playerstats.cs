using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxhealth;

    private float currenthealth;

    public Newvidamanager healthbar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = maxhealth;

        healthbar.setslidermax(maxhealth);

    }

    public void takedamage(float amount)
    {
        currenthealth -= amount;
        healthbar.setslider(currenthealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            takedamage(20f);
        }
    }

}
