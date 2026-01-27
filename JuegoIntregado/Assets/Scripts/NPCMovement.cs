using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    public float velocidad = 2f;

    private Transform destinoActual;
    private bool puedeMoverse = true;
    private bool esperandoDecision = false;

    private NPCSpawner spawner; // referencia al spawner para avisar cuando destruir

    void Start()
    {
        destinoActual = puntoB;
        spawner = FindObjectOfType<NPCSpawner>();
    }

    void Update()
    {
        if (!puedeMoverse || destinoActual == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            destinoActual.position,
            velocidad * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, destinoActual.position) < 0.05f)
        {
            LlegadaAlPunto();
        }
    }

    void LlegadaAlPunto()
    {
        // Llegó al punto de diálogo
        if (destinoActual == puntoB)
        {
            puedeMoverse = false;
            esperandoDecision = true;

            // Avisamos al spawner que este es el NPC activo
            if (spawner != null)
                spawner.npcActivo = this;

            // Aquí activas tu UI
            // DialogoManager.Instance.MostrarDialogo(this);
        }
        else
        {
            // Llegó a su salida final → destruir y avisar al spawner
            if (spawner != null)
                spawner.SpawnSiguienteNPC();

            Destroy(gameObject);
        }
    }

    public void Aceptar()
    {
        if (!esperandoDecision) return;

        destinoActual = salidaAceptar;
        ReanudarMovimiento();
    }

    public void Rechazar()
    {
        if (!esperandoDecision) return;

        destinoActual = salidaRechazar;
        ReanudarMovimiento();
    }

    void ReanudarMovimiento()
    {
        esperandoDecision = false;
        puedeMoverse = true;
    }
}

