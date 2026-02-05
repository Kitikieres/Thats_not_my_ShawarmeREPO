using UnityEngine;
using UnityEngine.InputSystem;

public class RadioInteractiva : MonoBehaviour
{
    public AudioSource musicaRadio;
    private bool encendida = false;

    private Camera cam;

    private void Start()
    {
        musicaRadio = GetComponent<AudioSource>();
        musicaRadio.loop = true;
        musicaRadio.Stop();

        cam = Camera.main;
    }

    private void Update()
    {
        if (cam == null)
        {
            cam = Camera.main;
            return;
        }

        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.transform == transform)
            {
                Debug.Log("CLICK EN RADIO");

                if (encendida)
                {
                    encendida = false;
                    musicaRadio.Stop();
                }
                else
                {
                    encendida = true;
                    musicaRadio.Play();
                }
            }
        }
    }
}
