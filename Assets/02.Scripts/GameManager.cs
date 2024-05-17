using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public static GameManager Instance => s_instance == null ? null : s_instance;

    public int Score;
    public int BestScore;

    public GameObject ball;

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

    private void Start()
    {
        
    }



    public void GameStart()
    {
        Score = 0;
        SceneManager.LoadScene("MainScene");
        InvokeRepeating("MakeBall", 0.0f, 1.0f);
    }

    void MakeBall()
    {
        Instantiate(ball);
    }


    public void GameOver()
    {
        //Todo: MainScene 완성 후 추가 예정 => 모달창 띄우기(점수 및 최고 점수 업데이트)
    }

    public static void OpenStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OpenSettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}