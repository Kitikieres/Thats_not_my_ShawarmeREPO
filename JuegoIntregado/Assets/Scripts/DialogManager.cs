using UnityEngine;
using TMPro; // si usas TextMeshPro
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

    private string[] lineasActuales;
    private int indice = 0;

    void Awake()
    {
        Instance = this;
        panelDialogo.SetActive(false);
    }

    // Mostrar diálogo de un NPC
    public void MostrarDialogo(GameObject npc)
    {
        var dialog = npc.GetComponent<NPCDialog>();
        if (dialog == null) return;

        lineasActuales = dialog.ObtenerDialogo();
        indice = 0;
        panelDialogo.SetActive(true);
        textoDialogo.text = lineasActuales[indice];
    }

    // Pasar a la siguiente línea
    public void SiguienteLinea()
    {
        if (lineasActuales == null) return;

        indice++;
        if (indice < lineasActuales.Length)
        {
            textoDialogo.text = lineasActuales[indice];
        }
        else
        {
            // Fin del diálogo, opcional ocultar panel
            panelDialogo.SetActive(false);
        }
    }
}

