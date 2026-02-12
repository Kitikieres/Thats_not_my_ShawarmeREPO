using UnityEngine;

public class Tarjeta : MonoBehaviour
{
    [Header("Imagen que corresponde a esta tarjeta")]
    public Sprite imagenDelNPC;  // Imagen que debe abrirse al hacer clic

    private void OnMouseDown()
    {
        // Al hacer clic, llamar al Canvas para que abra la imagen
        if (CanvasManager.Instance != null)
        {
            CanvasManager.Instance.Abrir(imagenDelNPC);
        }
        else
        {
            Debug.LogError("❌ CanvasManager no encontrado");
        }
    }
}

