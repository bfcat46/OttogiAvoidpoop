using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;

    private void Awake()
    {
        if (s_instance != null) return;
        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public static GameManager Instance => s_instance == null ? null : s_instance;

    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingScene");
    }
    
    public void GameOver()
    {
                
    }
}
