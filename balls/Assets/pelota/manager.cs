using UnityEngine;

public class manager : MonoBehaviour
{
    [SerializeField] meta meta;
    [SerializeField] bool jugando = true;


    public bool Jugando
    {
        get { return jugando; }
    }

    private void Update()
    {
        if (meta != null)
        {
            if (meta.AlcanzoMeta && jugando)
            {
                Debug.Log("gano");
                jugando = false;
            }
        }
    }






















}
