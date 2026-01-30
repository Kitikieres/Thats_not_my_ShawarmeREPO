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
        // Posición inicial
        transform.position = puntoA.position;
        destinoActual = puntoB;

        // Referencias a otros scripts del NPC
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
        // ➜ Llega al punto B
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
        // ➜ Sale del escenario
        else if (destinoActual == salidaAceptar || destinoActual == salidaRechazar)
        {
            if (spawner != null)
                spawner.NPCFinalizado();

            Destroy(gameObject);
        }
    }

    // ▶️ El objeto SALE del NPC y va al empty
    void MostrarObjeto()
    {
        if (objetoNPC == null || puntoEntregaObjeto == null || deslizante == null)
            return;

        Vector3 inicio = transform.position;
        Vector3 destino = puntoEntregaObjeto.position;

        deslizante.DeslizarDesdeHasta(inicio, destino);
    }

    // ◀️ El objeto vuelve del empty al NPC y se guarda
    void GuardarObjeto()
    {
        if (objetoNPC == null || puntoEntregaObjeto == null || deslizante == null)
            return;

        Vector3 inicio = puntoEntregaObjeto.position;
        Vector3 destino = transform.position;

        deslizante.DeslizarYGuardar(inicio, destino);
    }

    // ✔️ ACEPTAR
    public void Aceptar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        GuardarObjeto();

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();

        // Evaluar checklist y mostrar reacción del NPC
        if (checklistNPC != null && ChecklistManager.Instance != null && DialogManager.Instance != null)
        {
            bool correcto = checklistNPC.EvaluarChecklist(
                ChecklistManager.Instance.ObtenerResultado()
            );

            DialogManager.Instance.MostrarDialogo(
                correcto ? checklistNPC.dialogoCorrecto : checklistNPC.dialogoIncorrecto
            );
        }

        if (rutinaSalida != null)
            StopCoroutine(rutinaSalida);

        rutinaSalida = StartCoroutine(EsperarYSalir(salidaAceptar));
    }

    // ❌ RECHAZAR
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
        destinoActual = null; // se queda quieto

        yield return new WaitForSeconds(tiempoEsperaDecision);

        destinoActual = salida;
    }
}
