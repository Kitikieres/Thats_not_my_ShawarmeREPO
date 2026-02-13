using UnityEngine;

public class NPCInteractuarEleccion : MonoBehaviour
{
    private NPCDialogoEleccion dialogo;

    void Start()
    {
        dialogo = GetComponent<NPCDialogoEleccion>();
    }

    
    public void ClickManual()
    {
        

        if (dialogo != null && DialogManagerEleccion.Instance != null)
        {
            DialogManagerEleccion.Instance.IniciarDialogo(dialogo);
        }
    }
}
