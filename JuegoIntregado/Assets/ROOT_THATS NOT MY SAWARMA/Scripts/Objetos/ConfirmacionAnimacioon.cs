using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmacionJuego : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject panelConfirmacion;

    public Animator menuAnimator;      // tu objeto con la animación
    public float tiempoAnimacion = 1.5f; // lo que dure tu animación

    // --- BOTÓN NUEVA PARTIDA (abre confirmación) ---
    public void MostrarConfirmacionJugar()
    {
        menuPrincipal.SetActive(false);
        panelConfirmacion.SetActive(true);
    }

    // --- BOTÓN NO (cancela) ---
    public void Cancelar()
    {
        panelConfirmacion.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    // --- BOTÓN SÍ (reproduce animación y luego carga nivel) ---
    public void ConfirmarNuevaPartida()
    {
        panelConfirmacion.SetActive(false);   // oculta el cartel
        StartCoroutine(AnimarYLuegoCargar());
    }

    IEnumerator AnimarYLuegoCargar()
    {
        // 1️⃣ Ejecuta tu animación
        menuAnimator.SetTrigger("StartGame");

        // 2️⃣ Espera a que termine
        yield return new WaitForSeconds(tiempoAnimacion);

        // 3️⃣ Carga el nivel 1
        SceneManager.LoadScene(1);
    }
}
