using UnityEngine;

public class CartelInteractivo : MonoBehaviour
{
    public PanelCartelManager panelCartel;

    public void AbrirCartel()
    {
        if (panelCartel != null)
            panelCartel.Abrir();
    }
}
