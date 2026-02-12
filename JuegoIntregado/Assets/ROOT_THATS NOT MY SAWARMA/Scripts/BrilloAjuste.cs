using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Image brightnessPanel;
    public Slider brightnessSlider;

    private const string BrightnessKey = "BrightnessValue";

    void Start()
    {
        float savedValue = PlayerPrefs.GetFloat(BrightnessKey, 0f);
        brightnessSlider.value = savedValue;
        SetBrightness(savedValue);

        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        Color color = brightnessPanel.color;
        color.a = value;
        brightnessPanel.color = color;

        PlayerPrefs.SetFloat(BrightnessKey, value);
        PlayerPrefs.Save();
    }

}
