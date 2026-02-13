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
        
        menuAnimator.SetTrigger("StartGame");

        
        yield return new WaitForSeconds(tiempoAnimacion);

        
        SceneManager.LoadScene(1);
    }
}

