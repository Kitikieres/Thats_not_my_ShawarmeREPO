using UnityEngine;

public class CerrarPanel : MonoBehaviour
{
    public void Cerrar()
    {
        if (PanelInfoManager.Instance != null)
            PanelInfoManager.Instance.Cerrar();
    }
}
