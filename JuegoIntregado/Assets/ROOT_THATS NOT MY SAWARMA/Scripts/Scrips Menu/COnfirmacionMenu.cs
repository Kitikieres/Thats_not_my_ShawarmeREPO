using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmacion : MonoBehaviour
{
    public GameObject panelConfirmacion;
    public GameObject menuPrincipal;

    public void MostrarConfirmacionSalir()
    {
        menuPrincipal.SetActive(false);
        panelConfirmacion.SetActive(true);
    }

    public void Cancelar()
    {
        panelConfirmacion.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void ConfirmarSalir()
    {
        Application.Quit();
        Debug.Log("Has abandonado tu puesto hdp"); // Solo para que lo veas en el Editor
    }

    public void ConfirmarNuevaPartida()
    {
        SceneManager.LoadScene(1); // Tu Nivel 1
    }
}
