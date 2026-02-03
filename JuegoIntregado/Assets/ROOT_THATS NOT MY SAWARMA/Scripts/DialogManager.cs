using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{
    public static DialogManager Instance;

    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

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

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickEnDialogo();
    }

    public void MostrarDialogo(string texto)
    {
        if (panelDialogo == null || textoDialogo == null)
            return;

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
        {
            if (rutinaEscritura != null)
                StopCoroutine(rutinaEscritura);

            textoDialogo.text = textoCompleto;
            escribiendo = false;
            return;
        }

        CerrarDialogo();
    }

    public void CerrarDialogo()
    {
        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }
}
