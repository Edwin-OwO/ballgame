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

}
