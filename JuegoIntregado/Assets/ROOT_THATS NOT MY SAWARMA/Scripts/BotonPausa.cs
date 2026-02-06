using UnityEngine;

public class PauseMenuButton : MonoBehaviour
{
    public GameObject pauseMenu; // Arrastra aquí tu panel de pausa

    // Método para abrir el menú
    public void OpenPauseMenu()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // Muestra el panel
            Time.timeScale = 0f;       // Pausa el juego
        }
    }

    // Método para cerrar el menú (opcional)
    public void ClosePauseMenu()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Oculta el panel
            Time.timeScale = 1f;        // Reanuda el juego
        }
    }
}
