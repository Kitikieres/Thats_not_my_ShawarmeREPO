using UnityEngine;

public class NPCInteractuar : MonoBehaviour
{
    private NPCDialogo dialogo;
    private bool estaHablando = false;

    void Start()
    {
        dialogo = GetComponent<NPCDialogo>();
    }

    void OnMouseDown()
    {
        
        if (DialogManager.Instance == null)
            return;

        
        if (estaHablando)
        {
            DialogManager.Instance.CerrarDialogo();
            estaHablando = false;
        }
        else
        {
            
            if (dialogo != null)
            {
                DialogManager.Instance.MostrarDialogo(dialogo.textoDialogo);
                estaHablando = true;
            }
        }
    }

    
    public void DialogoCerrado()
    {
        estaHablando = false;
    }
}
