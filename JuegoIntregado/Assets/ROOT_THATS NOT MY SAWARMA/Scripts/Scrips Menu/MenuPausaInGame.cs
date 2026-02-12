using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject pauseMenu; // Panel del menú de pausa

    // Botón: Reanudar juego
    public void ResumeGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        Time.timeScale = 1f; // Reanuda el juego
    }

    // Botón: Volver al menú de inicio
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo se reanude
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena de inicio
    }

    // Botón: Salir del juego (opcional, solo funciona en build)
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
