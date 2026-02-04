using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPCs (prefabs)")]
    public GameObject[] npcPrefabs;

    [Header("Puntos")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    [Header("Delay entre NPCs")]
    public float delayEntreNPCs = 2f;

    private List<GameObject> colaNPCs = new List<GameObject>();
    private NPCMovement npcActual;

    void Start()
    {
        PrepararColaAleatoria();
        SpawnNPC();
    }

    void PrepararColaAleatoria()
    {
        colaNPCs.Clear();
        colaNPCs.AddRange(npcPrefabs);

        for (int i = 0; i < colaNPCs.Count; i++)
        {
            int randomIndex = Random.Range(i, colaNPCs.Count);
            GameObject temp = colaNPCs[i];
            colaNPCs[i] = colaNPCs[randomIndex];
            colaNPCs[randomIndex] = temp;
        }
    }

    void SpawnNPC()
    {
        if (npcActual != null) return;

        
        if (colaNPCs.Count == 0)
        {
            Debug.Log("🏁 No quedan más kebabs → FIN DE PARTIDA");

            if (GameManager.Instance != null)
                GameManager.Instance.FinDePartida();

            return;
        }

        GameObject npc = Instantiate(colaNPCs[0]);
        colaNPCs.RemoveAt(0);

        NPCMovement mov = npc.GetComponent<NPCMovement>();
        mov.spawner = this;
        mov.puntoA = puntoA;
        mov.puntoB = puntoB;
        mov.salidaAceptar = salidaAceptar;
        mov.salidaRechazar = salidaRechazar;

        npcActual = mov;
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
