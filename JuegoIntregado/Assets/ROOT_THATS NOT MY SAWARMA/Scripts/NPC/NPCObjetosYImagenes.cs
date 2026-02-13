using UnityEngine;
using UnityEngine.UI;  

public class NPCObjetosYImagenes : MonoBehaviour
{
    [Header("Configuración del NPC")]
    public GameObject objetoNPC;  
    public Sprite imagenNPC;      
    public Transform puntoEntregaObjeto;  

    [Header("Componente de deslizamiento")]
    private ObjetoDeslizante deslizante;

    void Start()
    {
        if (objetoNPC != null)
        {
            deslizante = objetoNPC.GetComponent<ObjetoDeslizante>();
            objetoNPC.SetActive(false); 
        }
    }

    public void MostrarObjetoYImagen()
    {
       
        if (objetoNPC != null)
        {
            objetoNPC.SetActive(true);
            deslizante.DeslizarDesdeHasta(transform.position, puntoEntregaObjeto.position);  
        }

        
        MostrarImagen();
    }

    private void MostrarImagen()
    {
        if (imagenNPC != null)
        {
            
            Image img = FindObjectOfType<Image>();  
            img.sprite = imagenNPC;  
            img.enabled = true;  
        }
    }

    public void OcultarImagen()
    {
        Image img = FindObjectOfType<Image>();
        img.enabled = false;  
    }
}
