using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInputHandler : MonoBehaviour
{
    public InputAction pauseAction; 
    public GameObject pauseMenu;    

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
       
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        
        if (pauseMenu.activeSelf)
            Time.timeScale = 0f; 
        else
            Time.timeScale = 1f; 
    }
}
