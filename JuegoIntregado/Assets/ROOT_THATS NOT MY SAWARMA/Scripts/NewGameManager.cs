using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : MonoBehaviour
{
    public CanvasGroup titulo;
    public CanvasGroup menuBotones;

    public string escenaJuego;   // nombre de tu escena del juego
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

        // Opcional: desactivar UI cuando ya no se ve
        titulo.gameObject.SetActive(false);
        menuBotones.gameObject.SetActive(false);

        // Ahora sí, cargar el juego
        SceneManager.LoadScene(escenaJuego);
    }
}
