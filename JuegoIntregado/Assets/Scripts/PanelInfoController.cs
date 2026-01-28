using UnityEngine;

public class PanelInfoManager : MonoBehaviour
{
    public static PanelInfoManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        gameObject.SetActive(false); // empieza oculto
    }

    public void Abrir()
    {
        gameObject.SetActive(true);
    }

    public void Cerrar()
    {
        gameObject.SetActive(false);
    }
}
