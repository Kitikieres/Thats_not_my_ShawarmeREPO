using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartComplete : MonoBehaviour
{
    
    public Animator menuAnimator;

   
    public string triggerNombre = "StartGame";

    
    public void IniciarPartida()
    {
        
        menuAnimator.SetTrigger(triggerNombre);
        Debug.Log("Funciona boton");
    }

    
    public void AnimacionTerminada()
    {
       
        SceneManager.LoadScene(1);
    }
}
