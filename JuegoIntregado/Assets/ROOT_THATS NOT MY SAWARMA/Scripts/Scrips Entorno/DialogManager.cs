using UnityEngine;
using TMPro;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

    public float velocidadTexto = 0.03f;

    private bool escribiendo = false;
    private string textoCompleto;
    private Coroutine rutinaEscritura;

    // Para avisar al NPC actual
    

    void Awake()
    {
        Instance = this;
        panelDialogo.SetActive(false);
    }

    public void MostrarDialogo(string texto)
    {
        panelDialogo.SetActive(true);
        textoCompleto = texto;

        // Buscar quién llamó
       

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
}
