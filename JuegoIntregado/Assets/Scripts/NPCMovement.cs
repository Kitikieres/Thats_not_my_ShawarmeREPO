using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Puntos de movimiento")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    [Header("Velocidad de movimiento")]
    public float velocidad = 2f;

    private Transform destinoActual;
    private bool puedeMoverse = true;
    private bool esperandoDecision = false;

    private NPCSpawner spawner;

    void Start()
    {
        destinoActual = puntoB; // comienza yendo al puntoB
        spawner = FindObjectOfType<NPCSpawner>();
    }

    void Update()
    {
        if (!puedeMoverse || destinoActual == null) return;

        // Movimiento
        transform.position = Vector2.MoveTowards(
            transform.position,
            destinoActual.position,
            velocidad * Time.deltaTime
        );

        // Comprobar llegada
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

            // Mostramos el diálogo propio del NPC
            DialogManager.Instance.MostrarDialogo(gameObject);
        }
        else
        {
            // Llegó a salida final → destruir y avisar al spawner
            if (spawner != null)
                spawner.SpawnSiguienteNPC();

            Destroy(gameObject);
        }
    }

    // 🔵 Llamado desde los botones de UI
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

