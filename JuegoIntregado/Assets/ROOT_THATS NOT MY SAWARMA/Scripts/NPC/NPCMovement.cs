using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public NPCSpawner spawner;

    public Transform puntoA;
    public Transform puntoB;
    public Transform salidaAceptar;
    public Transform salidaRechazar;

    public float velocidad = 2f;

    public GameObject objetoNPC;

    public Transform puntoEntregaObjeto;

    public float tiempoEsperaDecision = 1f;

    private Transform destinoActual;
    private bool esperandoDecision = false;
    private bool dialogoMostrado = false;

    private ObjetoDeslizante deslizante;
    private NPCDialogo dialogoNPC;
    private NPCChecklist checklistNPC;
    private NPCEstado estadoNPC;

    private Coroutine rutinaSalida;

    private Animator animator;

    void Start()
    {
        transform.position = puntoA.position;
        destinoActual = puntoB;

        dialogoNPC = GetComponent<NPCDialogo>();
        checklistNPC = GetComponent<NPCChecklist>();
        estadoNPC = GetComponent<NPCEstado>();
        animator = GetComponent<Animator>();

        if (objetoNPC != null)
        {
            deslizante = objetoNPC.GetComponent<ObjetoDeslizante>();
            objetoNPC.SetActive(false);
        }

        ActualizarAnimacion();
    }

    void Update()
    {
        if (destinoActual != null)
        {
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

        ActualizarAnimacion();
    }

    void ActualizarAnimacion()
    {
        if (animator == null) return;

        bool caminando = destinoActual != null;

        animator.SetBool("isWalking", caminando);
    }

    void LlegarDestino()
    {
        if (destinoActual == puntoB && !esperandoDecision && !dialogoMostrado)
        {
            destinoActual = null;
            esperandoDecision = true;
            dialogoMostrado = true;

            MostrarObjeto();

            if (dialogoNPC != null && DialogManager.Instance != null)
            {
                DialogManager.Instance.MostrarDialogo(dialogoNPC.textoDialogo);
            }
        }
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

    public void Aceptar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        GuardarObjeto();

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();

        if (estadoNPC != null && estadoNPC.esMalo)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AceptarMalo();
            }
        }

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

        ActualizarAnimacion();

        yield return new WaitForSeconds(tiempoEsperaDecision);

        destinoActual = salida;

        ActualizarAnimacion();
    }
}
