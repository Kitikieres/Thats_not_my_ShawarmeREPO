using UnityEngine;
using UnityEngine.InputSystem;

public class ClickMundo2D : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 posicion = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(posicion, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("CLICK A: " + hit.collider.name);

                

            }
        }
    }
}
