using UnityEngine;



public class Partemovil : MonoBehaviour
{
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ (Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.WorldToScreenPoint(screenPosition);
        return worldPosition;
    }
    // funcion para obtener la poscion del mouse dentro del juego

    private Transform aimtransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        aimtransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 mousePosition = GetMouseWorldPosition();
       Vector3 aimDirection = (mousePosition - transform.position).normalized;  
       float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        // el primero saca angulo en radianes y el segundo lo traduce a grados

       aimtransform.eulerAngles = new Vector3 (0,0, angle);
       Debug.Log(angle);
    }

  


}
