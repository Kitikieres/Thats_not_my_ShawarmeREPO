using UnityEngine;

public class MoscaDentroPantalla : MonoBehaviour
{
    public float velocidad = 2f;
    public float cambioDireccion = 0.4f;

    private Vector2 direccion;
    private float tiempo;

   
    private float xMin, xMax, yMin, yMax;

    void Start()
    {
        NuevaDireccion();

        
        Vector3 esquinaInferior = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 esquinaSuperior = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        xMin = esquinaInferior.x;
        xMax = esquinaSuperior.x;
        yMin = esquinaInferior.y;
        yMax = esquinaSuperior.y;
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        
        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;

      
        if (tiempo >= cambioDireccion)
        {
            NuevaDireccion();
            tiempo = 0f;
        }

       
        Vector3 pos = transform.position;

        if (pos.x < xMin)
        {
            pos.x = xMin;
            direccion.x *= -1;   
        }

        if (pos.x > xMax)
        {
            pos.x = xMax;
            direccion.x *= -1;
        }

        if (pos.y < yMin)
        {
            pos.y = yMin;
            direccion.y *= -1;
        }

        if (pos.y > yMax)
        {
            pos.y = yMax;
            direccion.y *= -1;
        }

        transform.position = pos;
    }

    void NuevaDireccion()
    {
        direccion = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }
}
