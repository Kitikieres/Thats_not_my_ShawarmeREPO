using UnityEngine;

[System.Serializable]
public class DialogoNPC
{
    public string[] lineas; // Las líneas de diálogo de este NPC
}

public class NPCDialog : MonoBehaviour
{
    [Header("Diálogo de este NPC")]
    public DialogoNPC dialogo;

    // Este método devuelve las líneas del diálogo
    public string[] ObtenerDialogo()
    {
        return dialogo.lineas;
    }
}
