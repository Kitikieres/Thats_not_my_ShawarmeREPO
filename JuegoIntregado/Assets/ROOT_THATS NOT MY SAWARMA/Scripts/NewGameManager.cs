using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : MonoBehaviour
{
    public CanvasGroup titulo;
    public CanvasGroup menuBotones;

    public string escenaJuego;  
    public float fadeDuracion = 1f;

    public void PulsarNewGame()
    {
        StartCoroutine(FadeOutMenuYEntrar());
    }

    IEnumerator FadeOutMenuYEntrar()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime / fadeDuracion;

            titulo.alpha = t;
            menuBotones.alpha = t;

            yield return null;
        }

       
        titulo.gameObject.SetActive(false);
        menuBotones.gameObject.SetActive(false);

       
        SceneManager.LoadScene(escenaJuego);
    }
}
