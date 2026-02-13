using UnityEngine;

public class PersistenteEntreEscenas : MonoBehaviour
{
    private static PersistenteEntreEscenas instancia;

    void Awake()
    {
        
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }
}
