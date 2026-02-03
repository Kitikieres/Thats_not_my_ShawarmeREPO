using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonConAnimacion : MonoBehaviour
{
    public Animator animador;      // arrastra aquí tu objeto con Animator
    public string escenaDestino;   // nombre de la escena a cargar
    public float tiempoEspera = 1.2f; // tiempo de la animación

    public void OnBotonClick()
    {
        StartCoroutine(CambiarEscenaConAnimacion());
    }

    IEnumerator CambiarEscenaConAnimacion()
    {
        // 1) Dispara la animación
        animador.SetTrigger("Activar");

        // 2) Espera a que termine la animación
        yield return new WaitForSeconds(tiempoEspera);

        // 3) Cambia de escena
        SceneManager.LoadScene(escenaDestino);
    }
}
