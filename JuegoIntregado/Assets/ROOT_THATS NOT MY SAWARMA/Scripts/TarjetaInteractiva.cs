using UnityEngine;

public class TarjetaInteractiva : MonoBehaviour
{
    [Header("Imagen grande que abrirá esta tarjeta")]
    public Sprite imagenGrande;

    // 👇 Esto detecta el click automáticamente
    private void OnMouseDown()
    {
        if (PanelInfoManager.Instance != null)
        {
            PanelInfoManager.Instance.Abrir(imagenGrande);
        }
    }
}
