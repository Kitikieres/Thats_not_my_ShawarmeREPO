using UnityEngine;
using UnityEngine.InputSystem; // importante

public class PlayerInputHandler : MonoBehaviour
{
    public InputAction pauseAction; // arrastra tu acción Pause aquí
    public GameObject pauseMenu;    // arrastra tu menú de pausa aquí

    private void OnEnable()
    {
        pauseAction.Enable();
        pauseAction.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        pauseAction.performed -= OnPausePressed;
        pauseAction.Disable();
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        // Activa o desactiva el menú de pausa
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        // Opcional: pausar el tiempo del juego
        if (pauseMenu.activeSelf)
            Time.timeScale = 0f; // pausa el juego
        else
            Time.timeScale = 1f; // reanuda
    }
}
