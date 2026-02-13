using UnityEngine;
using UnityEngine.InputSystem;

public class RadioInteractiva : MonoBehaviour
{
    public AudioSource musicaRadio;

    [Header("Clip por defecto")]
    public AudioClip clipRadio;

   
    public AudioSource musicaDeFondo;

    private bool encendida = false;
    private Camera cam;

    private void Start()
    {
        
        if (musicaRadio == null)
            musicaRadio = GetComponent<AudioSource>();

       
        if (musicaDeFondo == null)
            musicaDeFondo = GameObject.Find("MusicaDeFondo").GetComponent<AudioSource>(); 

       
        if (musicaRadio.clip == null && clipRadio != null)
        {
            musicaRadio.clip = clipRadio;
        }

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
                ToggleRadio();
            }
        }
    }

    void ToggleRadio()
    {
        if (musicaRadio.clip == null)
        {
            Debug.LogError("❌ La radio NO tiene AudioClip asignado");
            return;
        }

        encendida = !encendida;

        if (encendida)
        {
            
            if (musicaDeFondo.isPlaying)
                musicaDeFondo.Stop();
            musicaRadio.Play();
        }
        else
        {
            
            musicaRadio.Stop();
            if (!musicaDeFondo.isPlaying)
                musicaDeFondo.Play();
        }
    }
}
