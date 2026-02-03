using UnityEngine;
using UnityEngine.InputSystem;

public class Hover2DManager : MonoBehaviour
{
    private Hover2DHighlight actual;

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            Hover2DHighlight nuevo =
                hit.collider.GetComponent<Hover2DHighlight>();

            if (nuevo != actual)
            {
                actual?.Desactivar();
                actual = nuevo;
                actual?.Activar();
            }
        }
        else
        {
            actual?.Desactivar();
            actual = null;
        }
    }
}
