using UnityEngine;
using UnityEngine.UI;  // ✅ Necesario para usar Image

public class NPCObjetosYImagenes : MonoBehaviour
{
    [Header("Configuración del NPC")]
    public GameObject objetoNPC;  // El objeto que el NPC te da
    public Sprite imagenNPC;      // Imagen que aparece cuando el NPC da el objeto
    public Transform puntoEntregaObjeto;  // Punto donde el objeto debe llegar

    [Header("Componente de deslizamiento")]
    private ObjetoDeslizante deslizante;

    void Start()
    {
        if (objetoNPC != null)
        {
            deslizante = objetoNPC.GetComponent<ObjetoDeslizante>();
            objetoNPC.SetActive(false);  // Inicia oculto
        }
    }

    public void MostrarObjetoYImagen()
    {
        // Si hay un objeto que deslizar, activarlo y deslizarlo
        if (objetoNPC != null)
        {
            objetoNPC.SetActive(true);
            deslizante.DeslizarDesdeHasta(transform.position, puntoEntregaObjeto.position);  // Desliza el objeto hasta el punto
        }

        // Si hay una imagen, la mostrará (esto puede estar en el UI si lo deseas)
        MostrarImagen();
    }

    private void MostrarImagen()
    {
        if (imagenNPC != null)
        {
            // Aquí puedes poner código para mostrar la imagen, por ejemplo, en un Image en el UI
            // Dependiendo de tu sistema de UI, lo que podrías hacer es algo como:
            Image img = FindObjectOfType<Image>();  // Asume que solo hay un Image en la escena, o busca el adecuado
            img.sprite = imagenNPC;  // Cambia la imagen que aparece
            img.enabled = true;  // Hacer visible la imagen
        }
    }

    public void OcultarImagen()
    {
        Image img = FindObjectOfType<Image>();
        img.enabled = false;  // Ocultar la imagen
    }
}
