using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public static OptionsMenuManager instance;

    [Header("Sliders de Volumen")]
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    [Header("Panel de Opciones")]
    public GameObject optionsPanel;

    // Variables de volumen
    private float masterVolume = 1f;
    private float sfxVolume = 1f;
    private float musicVolume = 1f;

    void Awake()
    {
        // Singleton: solo un menú persiste entre escenas
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadOptions(); // Carga los valores guardados al iniciar
    }

    void Start()
    {
        // Conecta los sliders con los valores guardados
        if (masterVolumeSlider != null) masterVolumeSlider.value = masterVolume;
        if (sfxVolumeSlider != null) sfxVolumeSlider.value = sfxVolume;
        if (musicVolumeSlider != null) musicVolumeSlider.value = musicVolume;

        // Agrega listeners para actualizar los valores cuando se muevan los sliders
        if (masterVolumeSlider != null) masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        if (sfxVolumeSlider != null) sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        if (musicVolumeSlider != null) musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);

        // Inicialmente el panel está oculto
        if (optionsPanel != null) optionsPanel.SetActive(false);
    }

    void Update()
    {
        // Abrir/Cerrar menú con la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsPanel != null)
            {
                if (optionsPanel.activeSelf)
                    HideOptions();
                else
                    ShowOptions();
            }
        }
    }

    // Mostrar el menú
    public void ShowOptions()
    {
        if (optionsPanel != null) optionsPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }

    // Ocultar el menú
    public void HideOptions()
    {
        if (optionsPanel != null) optionsPanel.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        SaveOptions(); // Guarda automáticamente los cambios
    }

    // Métodos para actualizar volumen
    public void SetMasterVolume(float value)
    {
        masterVolume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
    }

    // Guardar los valores usando PlayerPrefs
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
        Debug.Log("Opciones guardadas");
    }

    // Cargar los valores guardados
    public void LoadOptions()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
}
