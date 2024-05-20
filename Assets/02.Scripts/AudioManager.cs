using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    public AudioClip clip;
    private VolumeSlider slider; // VolumeSlider 참조 변수 추가

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
        audioSource = GetComponent<AudioSource>();

        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        // 시작할 때 슬라이더를 찾아서 저장
        slider = FindObjectOfType<VolumeSlider>();
        // 시작시 슬라이더 안보이게하기
        if (slider != null)
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SettingScene") // 씬 이름을 지정합니다.
        {
            // 환경 설정 씬에서 슬라이더가 존재하고 있다면 활성화하고 볼륨 조절을 가능하게 설정
            if (slider != null)
            {
                slider.gameObject.SetActive(true);
                slider.SetSliderValue(audioSource.volume);
                slider.OnVolumeChange += SetVolume;
            }
        }
        else
        {
            // 다른 씬에서는 슬라이더를 비활성화
            if (slider != null)
            {
                slider.OnVolumeChange -= SetVolume;
                slider.gameObject.SetActive(false);
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }
}