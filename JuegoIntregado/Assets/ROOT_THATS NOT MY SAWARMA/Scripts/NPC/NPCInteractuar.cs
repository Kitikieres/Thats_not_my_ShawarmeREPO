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
        // Si no hay DialogManager, no hacemos nada
        if (DialogManager.Instance == null)
            return;

        // Si ya está hablando → cerrar
        if (estaHablando)
        {
            DialogManager.Instance.CerrarDialogo();
            estaHablando = false;
        }
        else
        {
            // Abrir diálogo del NPC
            if (dialogo != null)
            {
                DialogManager.Instance.MostrarDialogo(dialogo.textoDialogo);
                estaHablando = true;
            }
        }
    }

    // Lo llamará el DialogManager cuando se cierre
    public void DialogoCerrado()
    {
        estaHablando = false;
    }
}
