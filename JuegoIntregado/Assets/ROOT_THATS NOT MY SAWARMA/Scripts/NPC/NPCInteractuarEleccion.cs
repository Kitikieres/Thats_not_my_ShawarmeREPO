using UnityEngine;

public class NPCInteractuarEleccion : MonoBehaviour
{
    private NPCDialogoEleccion dialogo;

    void Start()
    {
        dialogo = GetComponent<NPCDialogoEleccion>();
    }

    // Esto lo llamará el raycast
    public void ClickManual()
    {
        Debug.Log("🍖 CLICK AL KEBAB DETECTADO POR RAYCAST");

        if (dialogo != null && DialogManagerEleccion.Instance != null)
        {
            DialogManagerEleccion.Instance.IniciarDialogo(dialogo);
        }
    }
}
