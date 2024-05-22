using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] 
    private Slider Slider;

    public delegate void VolumeChangeHandler(float volume);
    public event VolumeChangeHandler OnVolumeChange;

    private void Start()
    {
        if (Slider == null) return;
        Slider.gameObject.SetActive(true);
        Slider.onValueChanged.AddListener(HandleVolumeChange);
    }

    public void SetSliderValue(float volume)
    {
        if (Slider != null)
        {
            Slider.value = volume;
        }
    }

    private void HandleVolumeChange(float volume)
    {
        OnVolumeChange?.Invoke(volume);
    }
}