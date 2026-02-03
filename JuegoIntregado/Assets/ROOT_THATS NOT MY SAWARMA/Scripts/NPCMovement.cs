using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    [Header("Spawner")]
    public NPCSpawner spawner;

    [Header("Puntos")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    [Header("Movimiento")]
    public float velocidad = 2f;

    [Header("Objeto que deja el NPC")]
    public GameObject objetoNPC;

    [Header("Empty donde se queda el objeto")]
    public Transform puntoEntregaObjeto;

    [Header("Tiempo de espera tras decisión")]
    public float tiempoEsperaDecision = 1f;

    private Transform destinoActual;
    private bool esperandoDecision = false;

    private ObjetoDeslizante deslizante;
    private NPCDialogo dialogoNPC;
    private NPCChecklist checklistNPC;
    private Coroutine rutinaSalida;

    void Start()
    {
        transform.position = puntoA.position;
        destinoActual = puntoB;

        dialogoNPC = GetComponent<NPCDialogo>();
        checklistNPC = GetComponent<NPCChecklist>();

        if (objetoNPC != null)
        {
            deslizante = objetoNPC.GetComponent<ObjetoDeslizante>();
            objetoNPC.SetActive(false);
        }
    }

    void Update()
    {
        if (destinoActual == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destinoActual.position,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, destinoActual.position) < 0.05f)
        {
            LlegarDestino();
        }
    }

    void LlegarDestino()
    {
        // 👉 LLEGA AL PUNTO B
        if (destinoActual == puntoB && !esperandoDecision)
        {
            destinoActual = null;
            esperandoDecision = true;

            MostrarObjeto();

            // Diálogo inicial del NPC
            if (dialogoNPC != null && DialogManager.Instance != null)
            {
                DialogManager.Instance.MostrarDialogo(dialogoNPC.textoDialogo);
            }
        }
        // 👉 SALE DEL ESCENARIO
        else if (destinoActual == salidaAceptar || destinoActual == salidaRechazar)
        {
            if (spawner != null)
                spawner.NPCFinalizado();

            Destroy(gameObject);
        }
    }

    void MostrarObjeto()
    {
        if (objetoNPC == null || puntoEntregaObjeto == null || deslizante == null)
            return;

        deslizante.DeslizarDesdeHasta(
            transform.position,
            puntoEntregaObjeto.position
        );
    }

    void GuardarObjeto()
    {
        if (objetoNPC == null || puntoEntregaObjeto == null || deslizante == null)
            return;

        deslizante.DeslizarYGuardar(
            puntoEntregaObjeto.position,
            transform.position
        );
    }

    // ============================
    // 🔥 VUELVE EL SISTEMA ORIGINAL
    // ============================

    public void Aceptar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        GuardarObjeto();

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();

        if (rutinaSalida != null)
            StopCoroutine(rutinaSalida);

        rutinaSalida = StartCoroutine(EsperarYSalir(salidaAceptar));
    }

    public void Rechazar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        GuardarObjeto();

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();

        if (rutinaSalida != null)
            StopCoroutine(rutinaSalida);

        rutinaSalida = StartCoroutine(EsperarYSalir(salidaRechazar));
    }

    IEnumerator EsperarYSalir(Transform salida)
    {
        destinoActual = null;

        yield return new WaitForSeconds(tiempoEsperaDecision);

        destinoActual = salida;
    }
}
