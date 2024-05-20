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
    private int _count = 1;
    
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

    public void GameStart()
    {
        Time.timeScale = 1;
        Score = 0;
        SceneManager.LoadScene("MainScene");
        if (IsInvoking(nameof(MakeBall)))
        {
            CancelInvoke(nameof(MakeBall));
        }
        InvokeRepeating(nameof(MakeBall), 2.0f, 3.0f);
    }

    private void MakeBall()
    {
        Instantiate(Ball);
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
    }
}