using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeMenuUI : MonoBehaviour
{
    public CanvasGroup menuUI;
    public float duracionFade = 1f;

    public void ConfirmarNuevaPartida()
    {
        StartCoroutine(FadeOutYEntrar());
    }

    IEnumerator FadeOutYEntrar()
    {
        float tiempo = 0f;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            menuUI.alpha = 1 - (tiempo / duracionFade);
            yield return null;
        }

        menuUI.alpha = 0; // aseguramos que quede invisible
        SceneManager.LoadScene(1);
    }
}
