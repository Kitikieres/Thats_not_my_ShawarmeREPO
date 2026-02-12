using UnityEngine;
using UnityEngine.UI;  // Asegúrate de usar este namespace para trabajar con UI

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [Header("Panel donde se muestra la imagen")]
    public GameObject panelInfo;
    public Image imagenUI;  // La imagen en el panel

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (panelInfo != null)
        {
            panelInfo.SetActive(false);  // El panel comienza desactivado
        }
    }

    public void Abrir(Sprite imagen)
    {
        // Activar el panel
        if (panelInfo != null)
        {
            panelInfo.SetActive(true);
        }

        // Cambiar la imagen en el UI
        if (imagenUI != null && imagen != null)
        {
            imagenUI.sprite = imagen;
        }
    }

    public void Cerrar()
    {
        // Desactivar el panel
        if (panelInfo != null)
        {
            panelInfo.SetActive(false);
        }
    }
}
