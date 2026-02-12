using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void CargarNivel()
    {
        SceneManager.LoadScene(1);
    }


    public Animator menuAnimator;
    public float tiempoAnimacion = 1.5f;

    public void IniciarPartida()
    {
        StartCoroutine(AnimarYLuegoCargar());
    }

    IEnumerator AnimarYLuegoCargar()
    {
        // 1) Llamamos a tu animación
        menuAnimator.SetTrigger("StartGame");

        // 2) Esperamos a que termine
        yield return new WaitForSeconds(tiempoAnimacion);

        // 3) Cargamos el Nivel 1
        SceneManager.LoadScene(1);
    }
}

