using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class NPCChecklist : MonoBehaviour
{
    [Header("Respuestas del NPC")]
    [TextArea] public string respuestaFaltaDocumento;
    [TextArea] public string respuestaFaltaFoto;
    [TextArea] public string respuestaFaltaFirma;
    [TextArea] public string respuestaFaltaPermiso;

    [TextArea] public string respuestaNadaPreguntado;

    [Header("UI de Diálogo")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;

    // 🔥 Se ejecuta al cerrar checklist
    public void ResponderDesdeChecklist(HashSet<string> preguntas)
    {
        string respuesta = ObtenerRespuesta(preguntas);

        panelDialogo.SetActive(true);
        textoDialogo.text = respuesta;

        // 👉 Aquí YA NO movemos al NPC
        // Esperamos a que el jugador pulse Aceptar o Rechazar
    }

    public string ObtenerRespuesta(HashSet<string> preguntas)
    {
        if (preguntas.Contains("Toggle_FaltaDocumento"))
            return respuestaFaltaDocumento;

        if (preguntas.Contains("Toggle_FaltaFoto"))
            return respuestaFaltaFoto;

        if (preguntas.Contains("Toggle_FaltaFirma"))
            return respuestaFaltaFirma;

        if (preguntas.Contains("Toggle_FaltaPermiso"))
            return respuestaFaltaPermiso;

        return respuestaNadaPreguntado;
    }
}
