using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartComplete : MonoBehaviour
{
    // Este Animator es tu objeto que tiene la animación
    public Animator menuAnimator;

    // Nombre del Trigger en tu Animator
    public string triggerNombre = "StartGame";

    // Función que se llama cuando presionas el botón
    public void IniciarPartida()
    {
        // Activamos la animación
        menuAnimator.SetTrigger(triggerNombre);
        Debug.Log("Funciona boton");
    }

    // Función que se llamará al final de la animación usando Animation Event
    public void AnimacionTerminada()
    {
        // Cambiamos al primer nivel (Build Settings -> Nivel 1)
        SceneManager.LoadScene(1);
    }
}
