using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextoFadeLoop : MonoBehaviour
{
    public float velocidad = 1.5f;   // qué tan rápido hace el fade
    private Text texto;

    void Start()
    {
        texto = GetComponent<Text>();
        StartCoroutine(FadeLoop());
    }

    IEnumerator FadeLoop()
    {
        while (true)
        {
            // Fade In (aparece)
            for (float t = 0; t < 1; t += Time.deltaTime / velocidad)
            {
                Color c = texto.color;
                c.a = t;
                texto.color = c;
                yield return null;
            }

            // Fade Out (desaparece)
            for (float t = 1; t > 0; t -= Time.deltaTime / velocidad)
            {
                Color c = texto.color;
                c.a = t;
                texto.color = c;
                yield return null;
            }
        }
    }
}
