using UnityEngine;
using System.Collections.Generic;

public class NPCChecklist : MonoBehaviour
{
    [Header("Respuestas del NPC")]
    [TextArea] public string respuestaFaltaDocumento;
    [TextArea] public string respuestaFaltaFoto;
    [TextArea] public string respuestaFaltaFirma;
    [TextArea] public string respuestaFaltaPermiso;

    [TextArea] public string respuestaNadaPreguntado;

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
