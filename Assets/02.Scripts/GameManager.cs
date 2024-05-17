using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public static GameManager Instance => s_instance == null ? null : s_instance;

    private static Button s_startButton;
    private static Button s_settingButton;

    public int Score;
    public int BestScore;

    public GameObject Ball;

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartScene") return;
        
        if (s_startButton == null)
        {
            s_startButton = GameObject.FindWithTag("StartButton").GetComponent<Button>();
            s_startButton.onClick.AddListener(GameStart);
        }

        if (s_settingButton != null) return;
        s_settingButton = GameObject.FindWithTag("SettingButton").GetComponent<Button>();
        s_settingButton.onClick.AddListener(OpenSettingScene);
    }

    public void GameStart()
    {
        Score = 0;
        SceneManager.LoadScene("MainScene");
        InvokeRepeating(nameof(MakeBall), 0.0f, 1.0f);
    }

    private void MakeBall()
    {
        Instantiate(Ball);
    }

    public void GameOver()
    {
        //Todo: MainScene 완성 후 추가 예정 => 모달창 띄우기(점수 및 최고 점수 업데이트)
    }

    public void OpenStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OpenSettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}