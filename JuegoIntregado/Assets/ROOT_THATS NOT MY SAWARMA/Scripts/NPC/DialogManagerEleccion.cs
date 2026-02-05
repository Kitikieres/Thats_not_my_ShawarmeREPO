using UnityEngine;
using TMPro;

public class DialogManagerEleccion : MonoBehaviour
{
    public static DialogManagerEleccion Instance;

    [Header("UI")]
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

    public GameObject panelOpciones;
    public TMP_Text textoBotonA;
    public TMP_Text textoBotonB;

    private NPCDialogoEleccion npcActual;

    void Awake()
    {
        Instance = this;
        panelDialogo.SetActive(false);
        panelOpciones.SetActive(false);
    }

    public void IniciarDialogo(NPCDialogoEleccion npc)
    {
        npcActual = npc;

        panelDialogo.SetActive(true);
        panelOpciones.SetActive(true);

        textoDialogo.text = npc.textoInicial;

        textoBotonA.text = npc.opcionA;
        textoBotonB.text = npc.opcionB;
    }

    public void ElegirA()
    {
        if (npcActual == null) return;

        textoDialogo.text = npcActual.respuestaA;
        panelOpciones.SetActive(false);
    }

    public void ElegirB()
    {
        if (npcActual == null) return;

        textoDialogo.text = npcActual.respuestaB;
        panelOpciones.SetActive(false);
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        panelOpciones.SetActive(false);
        npcActual = null;
    }
}
