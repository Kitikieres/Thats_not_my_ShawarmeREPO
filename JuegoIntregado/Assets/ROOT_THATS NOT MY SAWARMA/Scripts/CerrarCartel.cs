using UnityEngine;

public class CerrarPanelCartel : MonoBehaviour
{
    public PanelCartelManager panel;

    public void Cerrar()
    {
        if (panel != null)
            panel.Cerrar();
    }
}
