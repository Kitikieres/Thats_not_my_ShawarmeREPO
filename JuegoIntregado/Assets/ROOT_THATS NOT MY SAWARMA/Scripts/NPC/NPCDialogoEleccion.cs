using UnityEngine;

public class NPCDialogoEleccion : MonoBehaviour
{
    [Header("Texto inicial del NPC")]
    [TextArea]
    public string textoInicial;

    [Header("Opciones del jugador")]
    public string opcionA;
    public string opcionB;

    [Header("Respuestas del NPC")]
    [TextArea] public string respuestaA;
    [TextArea] public string respuestaB;
}
