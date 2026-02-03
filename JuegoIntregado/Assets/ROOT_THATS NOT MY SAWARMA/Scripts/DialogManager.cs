using UnityEngine;
using TMPro;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [Header("UI")]
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;   

    [Header("Velocidad de escritura")]
    public float velocidadTexto = 0.03f;

    private bool escribiendo = false;
    private string textoCompleto;
    private Coroutine rutinaEscritura;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        panelDialogo.SetActive(false);
    }

    public void MostrarDialogo(string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            Debug.LogWarning("⚠️ DialogManager: texto vacío");
            return;
        }

        panelDialogo.SetActive(true);
        textoCompleto = texto;

        if (rutinaEscritura != null)
            StopCoroutine(rutinaEscritura);

        rutinaEscritura = StartCoroutine(EscribirTexto());
    }

    IEnumerator EscribirTexto()
    {
        escribiendo = true;
        textoDialogo.text = "";

        foreach (char c in textoCompleto)
        {
            textoDialogo.text += c;
            yield return new WaitForSeconds(velocidadTexto);
        }

        escribiendo = false;
    }

    public void ClickEnDialogo()
    {
        if (escribiendo)
            return;

        CerrarDialogo();
    }

    public void CerrarDialogo()
    {
        if (rutinaEscritura != null)
            StopCoroutine(rutinaEscritura);

        panelDialogo.SetActive(false);
    }

    public bool HaTerminadoDeHablar()
    {
        return !escribiendo;
    }
}
