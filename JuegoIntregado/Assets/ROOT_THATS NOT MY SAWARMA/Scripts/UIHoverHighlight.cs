using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIHoverHighlight : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    private Image image;
    private Color originalColor;

    [Header("Configuración visual")]
    public Color hoverColor = new Color(1f, 1f, 0.75f);
    public float scaleOnHover = 1.06f;

    private Vector3 originalScale;

    void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
        transform.localScale = originalScale * scaleOnHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
        transform.localScale = originalScale;
    }
}

