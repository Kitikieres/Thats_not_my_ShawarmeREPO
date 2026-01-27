using UnityEngine;

public class BotonDecision : MonoBehaviour
{
    public enum TipoDecision { Aceptar, Rechazar }

    [Header("Decisión del botón")]
    public TipoDecision decision;

    [Header("Referencia al spawner")]
    public NPCSpawner spawner;

    // Este método se llama desde OnClick del botón
    public void TomarDecision()
    {
        if (spawner == null || spawner.npcActivo == null) return;

        switch (decision)
        {
            case TipoDecision.Aceptar:
                Debug.Log("Has pulsado ACEPTAR");
                spawner.npcActivo.Aceptar();
                break;
            case TipoDecision.Rechazar:
                Debug.Log("Has pulsado RECHAZAR");
                spawner.npcActivo.Rechazar();
                break;
        }
    }
}
