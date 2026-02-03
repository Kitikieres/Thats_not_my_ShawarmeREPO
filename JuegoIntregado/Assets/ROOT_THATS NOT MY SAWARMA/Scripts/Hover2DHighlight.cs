using UnityEngine;

public class Hover2DHighlight : MonoBehaviour
{
    public Color colorResaltado = Color.yellow;
    [Range(1f, 2f)]
    public float escalaHover = 1.1f;

    private SpriteRenderer sprite;
    private Color colorOriginal;
    private Vector3 escalaOriginal;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorOriginal = sprite.color;
        escalaOriginal = transform.localScale;
    }

    public void Activar()
    {
        sprite.color = colorResaltado;
        transform.localScale = escalaOriginal * escalaHover;
    }

    public void Desactivar()
    {
        sprite.color = colorOriginal;
        transform.localScale = escalaOriginal;
    }
}
