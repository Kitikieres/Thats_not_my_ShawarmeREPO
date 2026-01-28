using UnityEngine;
using TMPro;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [Header("UI de diálogo")]
    public GameObject panelDialogo;   // Panel del diálogo
    public TMP_Text textoDialogo;     // Texto dentro del panel
    public float velocidadEscritura = 0.05f; // Tiempo entre letras

    private Coroutine escrituraCoroutine;
    private string[] lineasActuales;
    private int indice = 0;
    private bool dialogoActivo = false;

    void Awake()
    {
        Instance = this;
        panelDialogo.SetActive(false);
    }

    // Mostrar diálogo de un NPC
    public void MostrarDialogo(GameObject npc)
    {
        var dialog = npc.GetComponent<NPCDialog>();
        if (dialog == null || dialog.ObtenerDialogo().Length == 0) return;

        lineasActuales = dialog.ObtenerDialogo();
        indice = 0;

        panelDialogo.SetActive(true);
        dialogoActivo = true;

        if (escrituraCoroutine != null) StopCoroutine(escrituraCoroutine);
        escrituraCoroutine = StartCoroutine(EscribirLinea(lineasActuales[indice]));
    }

    IEnumerator EscribirLinea(string linea)
    {
        textoDialogo.text = "";
        foreach (char letra in linea)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }

    // Se llama desde el botón Aceptar o Rechazar
    public void CerrarDialogo()
    {
        if (!dialogoActivo) return;

        if (escrituraCoroutine != null)
        {
            StopCoroutine(escrituraCoroutine);
            escrituraCoroutine = null;
        }

        panelDialogo.SetActive(false);
        textoDialogo.text = "";
        dialogoActivo = false;
    }
}

