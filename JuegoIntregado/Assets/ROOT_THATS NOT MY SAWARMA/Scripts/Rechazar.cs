using UnityEngine;

public class BotonDecision : MonoBehaviour
{
    public enum TipoDecision { Aceptar, Rechazar }
    public TipoDecision decision;

    public NPCSpawner spawner;

    public void TomarDecision()
    {
        if (spawner == null) return;

        if (decision == TipoDecision.Aceptar)
        {
            spawner.AceptarNPC();
        }
        else
        {
            spawner.RechazarNPC();
        }
    }
}

