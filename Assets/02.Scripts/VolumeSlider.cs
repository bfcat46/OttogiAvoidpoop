using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    public delegate void VolumeChangeHandler(float volume);
    public event VolumeChangeHandler OnVolumeChange;

    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.gameObject.SetActive(true);
            volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
        }
    }

    public void SetSliderValue(float volume)
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
        }
    }

    private void HandleVolumeChange(float volume)
    {
        OnVolumeChange?.Invoke(volume);
    }
}