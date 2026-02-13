using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonConAnimacion : MonoBehaviour
{
    public Animator animador;      
    public string escenaDestino;   
    public float tiempoEspera = 1.2f; 

    public void OnBotonClick()
    {
        StartCoroutine(CambiarEscenaConAnimacion());
    }

    IEnumerator CambiarEscenaConAnimacion()
    {
        
        animador.SetTrigger("Activar");

        
        yield return new WaitForSeconds(tiempoEspera);

        
        SceneManager.LoadScene(escenaDestino);
    }
}
