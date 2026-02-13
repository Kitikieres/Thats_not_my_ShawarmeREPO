using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider musicSlider;

    private const string VolumeKey = "MusicVolume";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);

        musicSource.volume = savedVolume;
        musicSlider.value = savedVolume;

        musicSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }
}
