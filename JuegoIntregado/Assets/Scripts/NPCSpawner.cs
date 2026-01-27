using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPCSpawner : MonoBehaviour
{
    [Header("Prefabs de NPC")]
    public List<GameObject> listaNPCs; 
    public Transform puntoSpawn;

    [Header("Tiempo entre NPCs")]
    public float tiempoEspera = 2f;

    [HideInInspector]
    public NPCMovement npcActivo; 

    private int indiceSiguiente = 0;

    void Start()
    {
        
        SpawnSiguienteNPC();
    }

    public void SpawnSiguienteNPC()
    {
        if (indiceSiguiente >= listaNPCs.Count) return;

        StartCoroutine(SpawnConDelay(listaNPCs[indiceSiguiente]));
        indiceSiguiente++;
    }

    IEnumerator SpawnConDelay(GameObject npcPrefab)
    {
        yield return new WaitForSeconds(tiempoEspera);
        GameObject nuevoNPC = Instantiate(npcPrefab, puntoSpawn.position, Quaternion.identity);
        npcActivo = nuevoNPC.GetComponent<NPCMovement>();
    }
}
