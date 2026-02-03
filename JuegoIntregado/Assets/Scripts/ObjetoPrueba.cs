using UnityEngine;
using UnityEngine.InputSystem;

public class ObjetoPrueba : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseWorldPos =
                cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("CLICK DETECTADO EN OBJETO");

                if (PanelInfoManager.Instance != null)
                    PanelInfoManager.Instance.Abrir();
                else
                    Debug.LogError("❌ PanelInfoManager.Instance es NULL");
            }
        }
    }
}
