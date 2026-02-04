using UnityEngine;

public class PanelCartelManager : MonoBehaviour
{
    public GameObject overlayBloqueo;

    private void Awake()
    {
        overlayBloqueo.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Abrir()
    {
        overlayBloqueo.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Cerrar()
    {
        gameObject.SetActive(false);
        overlayBloqueo.SetActive(false);
    }
}

