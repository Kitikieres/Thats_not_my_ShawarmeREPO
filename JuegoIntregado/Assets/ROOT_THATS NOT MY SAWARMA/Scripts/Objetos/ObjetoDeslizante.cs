using UnityEngine;
using System.Collections;

public class ObjetoDeslizante : MonoBehaviour
{
    [Header("Deslizamiento")]
    public float duracion = 0.4f;

    private Coroutine rutina;

    public void DeslizarDesdeHasta(Vector3 inicio, Vector3 destino)
    {
        if (rutina != null)
            StopCoroutine(rutina);

        gameObject.SetActive(true);
        rutina = StartCoroutine(Deslizar(inicio, destino, false));
    }

    
    public void DeslizarYGuardar(Vector3 inicio, Vector3 destino)
    {
        if (rutina != null)
            StopCoroutine(rutina);

        gameObject.SetActive(true);
        rutina = StartCoroutine(Deslizar(inicio, destino, true));
    }

    IEnumerator Deslizar(Vector3 inicio, Vector3 destino, bool ocultarAlFinal)
    {
        float tiempo = 0f;
        transform.position = inicio;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = Mathf.Clamp01(tiempo / duracion);
            float suavizado = Mathf.SmoothStep(0f, 1f, t);

            transform.position = Vector3.Lerp(inicio, destino, suavizado);
            yield return null;
        }

        transform.position = destino;

        if (ocultarAlFinal)
            gameObject.SetActive(false);
    }
}
