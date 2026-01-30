using UnityEngine;

public class NPCMovement : MonoBehaviour
{
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

    [Header("Punto desde donde sale el objeto")]
    public Transform puntoEntregaObjeto; // 👈 EMPTY

    private Transform destinoActual;
    private bool esperandoDecision = false;

    void Start()
    {
        transform.position = puntoA.position;
        destinoActual = puntoB;

        if (objetoNPC != null)
            objetoNPC.SetActive(false);
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
        if (destinoActual == puntoB && !esperandoDecision)
        {
            destinoActual = null;
            esperandoDecision = true;

            MostrarObjeto();

            if (DialogManager.Instance != null)
                DialogManager.Instance.MostrarDialogo(gameObject);
        }
        else if (destinoActual == salidaAceptar || destinoActual == salidaRechazar)
        {
            if (spawner != null)
                spawner.NPCFinalizado();

            Destroy(gameObject);
        }
    }

    // 🎁 DESLIZAMIENTO DESDE EL EMPTY
    void MostrarObjeto()
    {
        if (objetoNPC == null || puntoEntregaObjeto == null) return;

        ObjetoDeslizante deslizante = objetoNPC.GetComponent<ObjetoDeslizante>();

        Vector3 inicio = puntoEntregaObjeto.position; // 🔥 AQUÍ
        Vector3 destino = puntoB.position;

        if (deslizante != null)
        {
            deslizante.DeslizarDesdeHasta(inicio, destino);
        }
        else
        {
            objetoNPC.transform.position = destino;
            objetoNPC.SetActive(true);
        }
    }

    void RecogerObjeto()
    {
        if (objetoNPC != null)
            objetoNPC.SetActive(false);
    }

    public void Aceptar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        RecogerObjeto();
        destinoActual = salidaAceptar;

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();
    }

    public void Rechazar()
    {
        if (!esperandoDecision) return;

        esperandoDecision = false;
        RecogerObjeto();
        destinoActual = salidaRechazar;

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();
    }
}

