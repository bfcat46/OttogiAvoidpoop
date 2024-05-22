using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;
    public AudioClip Clip;
    
    private VolumeSlider _slider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (Clip != null)
        {
            _audioSource.clip = Clip;
            _audioSource.Play();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        _slider = FindObjectOfType<VolumeSlider>();
        if (_slider != null)
        {
            _slider.gameObject.SetActive(false);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SettingScene")
        {
            if (_slider == null) return;
            _slider.gameObject.SetActive(true);
            _slider.SetSliderValue(_audioSource.volume);
            _slider.OnVolumeChange += SetVolume;
        }
        else if (_slider != null)
        {
            _slider.OnVolumeChange -= SetVolume;
            _slider.gameObject.SetActive(false);
        }
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }
}