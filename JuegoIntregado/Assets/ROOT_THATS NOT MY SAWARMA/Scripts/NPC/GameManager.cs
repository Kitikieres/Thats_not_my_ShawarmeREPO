using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Estado de la partida")]
    public bool aceptasteUnMalo = false;

    [Header("Escenas")]
    public string escenaVictoria;
    public string escenaDerrota;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    public void AceptarMalo()
    {
        aceptasteUnMalo = true;
    }

    
    public void FinDePartida()
    {
        if (aceptasteUnMalo)
        {
            SceneManager.LoadScene(escenaDerrota);
        }
        else
        {
            SceneManager.LoadScene(escenaVictoria);
        }
    }
}
