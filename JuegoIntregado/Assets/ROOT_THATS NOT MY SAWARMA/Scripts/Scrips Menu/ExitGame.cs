using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirJuegoEditor : MonoBehaviour
{
    public void EmpezarJuego(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Abandonando tu puesto de trabajo");

    }
}