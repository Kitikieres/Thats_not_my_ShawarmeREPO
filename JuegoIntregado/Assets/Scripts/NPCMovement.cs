using UnityEngine;

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

    [Header("Objeto del NPC (HIJO, instancia)")]
    public GameObject objetoNPC;

    private Transform destinoActual;
    private bool esperandoDecision = false;

    void Start()
    {
        if (puntoA == null || puntoB == null || salidaAceptar == null || salidaRechazar == null)
        {
            Debug.LogError("❌ NPCMovement: faltan puntos");
            Destroy(gameObject);
            return;
        }

        if (objetoNPC == null)
        {
            Debug.LogError("❌ NPCMovement: objetoNPC no asignado");
            Destroy(gameObject);
            return;
        }

        objetoNPC.SetActive(false);
        transform.position = puntoA.position;
        destinoActual = puntoB;
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
            LlegarDestino();
    }

    void LlegarDestino()
    {
        if (destinoActual == puntoB && !esperandoDecision)
        {
            esperandoDecision = true;
            destinoActual = null;

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

    void MostrarObjeto()
    {
        objetoNPC.transform.SetParent(null);
        objetoNPC.transform.position = new Vector3(
            puntoB.position.x,
            puntoB.position.y,
            0f
        );
        objetoNPC.transform.localScale = Vector3.one;
        objetoNPC.SetActive(true);

        Debug.Log("🎁 OBJETO MOSTRADO");
    }

    void RecogerObjeto()
    {
        objetoNPC.SetActive(false);
        Debug.Log("📦 OBJETO RECOGIDO");
    }

    public void Aceptar()
    {
        if (!esperandoDecision) return;

        RecogerObjeto();
        destinoActual = salidaAceptar;
        esperandoDecision = false;

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();
    }

    public void Rechazar()
    {
        if (!esperandoDecision) return;

        RecogerObjeto();
        destinoActual = salidaRechazar;
        esperandoDecision = false;

        if (DialogManager.Instance != null)
            DialogManager.Instance.CerrarDialogo();
    }
}

