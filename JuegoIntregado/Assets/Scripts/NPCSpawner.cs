using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] npcPrefabs;

    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    public float delayEntreNPCs = 2f;

    private int indiceActual = 0;
    private NPCMovement npcActual;

    void Start()
    {
        SpawnNPC();
    }

    void SpawnNPC()
    {
        if (npcActual != null) return;
        if (indiceActual >= npcPrefabs.Length) return;

        GameObject npc = Instantiate(npcPrefabs[indiceActual]);

        NPCMovement mov = npc.GetComponent<NPCMovement>();
        mov.spawner = this;
        mov.puntoA = puntoA;
        mov.puntoB = puntoB;
        mov.salidaAceptar = salidaAceptar;
        mov.salidaRechazar = salidaRechazar;

        npcActual = mov;
        indiceActual++;
    }

    public void NPCFinalizado()
    {
        npcActual = null;
        StartCoroutine(SpawnConDelay());
    }

    IEnumerator SpawnConDelay()
    {
        yield return new WaitForSeconds(delayEntreNPCs);
        SpawnNPC();
    }

    public void AceptarNPC()
    {
        if (npcActual != null)
            npcActual.Aceptar();
    }

    public void RechazarNPC()
    {
        if (npcActual != null)
            npcActual.Rechazar();
    }
}

