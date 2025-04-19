using UnityEngine;
using UnityEngine.UI;

public class Newvidamanager : MonoBehaviour
{
    public Slider healthsldier;

    public void setslider(float amount)
    {
        healthsldier.value = amount;
    }

    public void setslidermax(float amount)
    {
        healthsldier.maxValue = amount;
        setslider(amount);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
