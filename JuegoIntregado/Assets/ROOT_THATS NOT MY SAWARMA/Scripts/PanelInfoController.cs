using UnityEngine;
using UnityEngine.UI;

public class PanelInfoManager : MonoBehaviour
{
    public static PanelInfoManager Instance;

    [Header("Overlay que bloquea clicks")]
    public GameObject overlayBloqueo;

    [Header("Imagen UI donde se mostrará")]
    public Image imagenUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(false);

        gameObject.SetActive(false);
    }

    // 🔥 AHORA RECIBE LA IMAGEN
    public void Abrir(Sprite imagen)
    {
        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(true);

        gameObject.SetActive(true);

        if (imagenUI != null && imagen != null)
            imagenUI.sprite = imagen;
    }

    public void Cerrar()
    {
        gameObject.SetActive(false);

        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(false);
    }
}
