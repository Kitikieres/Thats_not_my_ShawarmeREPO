using UnityEngine;

public class NPCInteractuarEleccion : MonoBehaviour
{
    private NPCDialogoEleccion dialogo;

    void Start()
    {
        dialogo = GetComponent<NPCDialogoEleccion>();
    }

    void OnMouseDown()
    {
        if (dialogo != null && DialogManagerEleccion.Instance != null)
        {
            DialogManagerEleccion.Instance.IniciarDialogo(dialogo);
        }
    }
}
