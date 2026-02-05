using UnityEngine;
using TMPro;

public class DialogManagerEleccion : MonoBehaviour
{
    public static DialogManagerEleccion Instance;

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

        Debug.Log("🟢 INICIANDO DIALOGO");

        panelDialogo.SetActive(true);   // 👈 FORZADO
        panelOpciones.SetActive(true);  // 👈 FORZADO

        textoDialogo.text = npc.textoInicial;

        textoBotonA.text = npc.opcionA;
        textoBotonB.text = npc.opcionB;
    }

    public void ElegirA()
    {
        if (npcActual == null) return;

        Debug.Log("👉 ELEGISTE A");

        // ❗ SOLO ocultamos opciones
        panelOpciones.SetActive(false);

        // ❗ JAMÁS ocultamos panelDialogo aquí
        panelDialogo.SetActive(true);

        textoDialogo.text = npcActual.respuestaA;
    }

    public void ElegirB()
    {
        if (npcActual == null) return;

        Debug.Log("👉 ELEGISTE B");

        panelOpciones.SetActive(false);
        panelDialogo.SetActive(true);

        textoDialogo.text = npcActual.respuestaB;
    }

    public void CerrarDialogo()
    {
        Debug.Log("❌ CERRANDO DIALOGO");

        panelDialogo.SetActive(false);
        panelOpciones.SetActive(false);
        npcActual = null;
    }
}
