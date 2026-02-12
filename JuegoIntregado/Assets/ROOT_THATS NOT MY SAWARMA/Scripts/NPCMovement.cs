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
    
    private NPCEstado estadoNPC;            // 🔴 NUEVO
    private Coroutine rutinaSalida;

    void Start()
    {
        transform.position = puntoA.position;
        destinoActual = puntoB;

        dialogoNPC = GetComponent<NPCDialogo>();
        
        estadoNPC = GetComponent<NPCEstado>();   // 🔴 NUEVO

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

    // ✔️ ACEPTAR
    public void Aceptar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        GuardarObjeto();

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();

        // 🔴 LÓGICA CLAVE: SOLO AQUÍ SE DETECTA EL MALO
        if (estadoNPC != null && estadoNPC.esMalo)
        {
            if (GameManager.Instance != null)
            {
                Debug.Log("❌ ACEPTASTE UN KEBAB MALO");
                GameManager.Instance.AceptarMalo();
            }
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

        // 🟢 Rechazar a un malo es lo correcto → NO penaliza
        Debug.Log("✔ Rechazaste al NPC");

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
