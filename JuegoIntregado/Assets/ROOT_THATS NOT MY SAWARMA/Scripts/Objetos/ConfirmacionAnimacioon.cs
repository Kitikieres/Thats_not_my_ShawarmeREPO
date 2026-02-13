using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmacionJuego : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject panelConfirmacion;

    public Animator menuAnimator;      
    public float tiempoAnimacion = 1.5f; 

    
    public void MostrarConfirmacionJugar()
    {
        menuPrincipal.SetActive(false);
        panelConfirmacion.SetActive(true);
    }

    
    public void Cancelar()
    {
        panelConfirmacion.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    
    public void ConfirmarNuevaPartida()
    {
        panelConfirmacion.SetActive(false);   
        StartCoroutine(AnimarYLuegoCargar());
    }

    IEnumerator AnimarYLuegoCargar()
    {
        
        menuAnimator.SetTrigger("StartGame");

       
        yield return new WaitForSeconds(tiempoAnimacion);

        
        SceneManager.LoadScene(1);
    }
}
