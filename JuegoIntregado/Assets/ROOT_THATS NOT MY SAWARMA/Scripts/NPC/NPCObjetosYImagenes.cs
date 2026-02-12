using UnityEngine;

public class NPCObjetosYImagenes : MonoBehaviour
{
    [Header("Configuración del NPC")]
    public GameObject objetoNPC;  // El objeto que el NPC te da
    public Sprite imagenNPC;      // Imagen única para este NPC
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

        // Aquí se le pasa la imagen única del NPC al PanelInfoManager
        if (PanelInfoManager.Instance != null)
        {
            PanelInfoManager.Instance.Abrir(imagenNPC);  // Pasamos la imagen del NPC al panel
        }
    }
}
