using UnityEngine;

public class SalirJuegoEditor : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // DETIENE EL JUEGO EN UNITY
#else
        Application.Quit(); // Cierra el juego cuando esté exportado
#endif
    }
}
