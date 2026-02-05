using UnityEngine;

public class PersistenteEntreEscenas : MonoBehaviour
{
    private static PersistenteEntreEscenas instancia;

    void Awake()
    {
        // Si ya existe otro igual, destrúyelo
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        // Guarda esta instancia
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }
}
