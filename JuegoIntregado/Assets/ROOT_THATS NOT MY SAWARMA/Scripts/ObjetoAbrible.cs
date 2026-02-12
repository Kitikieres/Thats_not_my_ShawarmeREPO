using UnityEngine;
using UnityEngine.UI;

public class ObjetoAbrible : MonoBehaviour
{
    [Header("Imagen de este objeto (solo para este NPC)")]
    public Sprite imagenDeEsteObjeto;  // Imagen única para cada NPC

    [Header("UI donde se mostrará la imagen")]
    public Image imagenUI;            // La imagen UI en la escena
    public GameObject panelInfo;      // El panel que se activa

    private bool abierto = false;

    // 👇 Este es el click sobre el objeto
    void OnMouseDown()
    {
        Abrir();
    }

    public void Abrir()
    {
        if (abierto) return;

        abierto = true;

        // Activar el panel con la imagen
        panelInfo.SetActive(true);

        // Mostrar la imagen única de este NPC
        imagenUI.sprite = imagenDeEsteObjeto;

        Debug.Log("🟢 Abierto objeto: " + gameObject.name);
    }

    public void Cerrar()
    {
        abierto = false;
        panelInfo.SetActive(false);
    }
}

