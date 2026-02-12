using UnityEngine;

public class PanelInfoManager : MonoBehaviour
{
    public static PanelInfoManager Instance;

    [Header("Overlay que bloquea clicks")]
    public GameObject overlayBloqueo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Seguridad inicial
        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(false);

        gameObject.SetActive(false); // el panel empieza oculto
    }

    public void Abrir()
    {
        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(true);

        gameObject.SetActive(true);
    }

    public void Cerrar()
    {
        gameObject.SetActive(false);

        if (overlayBloqueo != null)
            overlayBloqueo.SetActive(false);
    }
}
