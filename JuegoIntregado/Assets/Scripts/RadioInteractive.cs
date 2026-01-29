using UnityEngine;

public class RadioInteractiva : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource musicaRadio;

    private bool encendida = false;

    private void Start()
    {
        if (musicaRadio == null)
        {
            musicaRadio = GetComponent<AudioSource>();
        }

        musicaRadio.loop = true;
        musicaRadio.Stop();
        encendida = false;
    }

    private void OnMouseDown()
    {
        if (encendida)
        {
            ApagarRadio();
        }
        else
        {
            EncenderRadio();
        }
    }

    void EncenderRadio()
    {
        encendida = true;
        musicaRadio.Play();
        Debug.Log("📻 Radio encendida");
    }

    void ApagarRadio()
    {
        encendida = false;
        musicaRadio.Stop();
        Debug.Log("📻 Radio apagada");
    }
}
