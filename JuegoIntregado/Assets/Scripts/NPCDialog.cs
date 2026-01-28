using UnityEngine;

[System.Serializable]
public class DialogoNPC
{
    public string[] lineas; // Líneas de diálogo de este NPC
}

public class NPCDialog : MonoBehaviour
{
    [Header("Diálogo de este NPC")]
    public DialogoNPC dialogo;

    // Devuelve las líneas del diálogo
    public string[] ObtenerDialogo()
    {
        return dialogo.lineas;
    }
}
