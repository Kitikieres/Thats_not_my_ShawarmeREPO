using UnityEngine;

using UnityEngine;

public class OpenMenuWithEscape : MonoBehaviour
{
    public GameObject menuPanel; // Panel de tu menú (asígnalo desde el inspector)

    void Update()
    {
        // Detecta si presionas Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPanel != null)
            {
                // Abre o cierra el menú
                menuPanel.SetActive(!menuPanel.activeSelf);

                // Pausa o reanuda el juego
                Time.timeScale = menuPanel.activeSelf ? 0f : 1f;
            }
        }
    }
}
