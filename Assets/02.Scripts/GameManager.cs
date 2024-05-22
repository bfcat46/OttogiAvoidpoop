using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public static GameManager Instance => s_instance == null ? null : s_instance;

    public int Score;
    public static int BestScore;

    [SerializeField]
    private GameObject GameOverModal;

    [SerializeField]
    private TextMeshProUGUI CurrentScoreTxt, BestScoreTxt;

    [SerializeField]
    private TextMeshProUGUI CurrentScoreResult, BestScoreResult;

    public GameObject[] Characters;

    private GameObject _ball;

    [SerializeField] private GameObject Apple;

    [HideInInspector]
    public bool IsGamePlaying;

    private void Awake()
    {
        if (s_instance != null) return;
        s_instance = this;
    }

    private void Start()
    {
        IsGamePlaying = true;
        GameOverModal.SetActive(false);
        BestScoreTxt.text = BestScore.ToString();
        Time.timeScale = 1;
        Score = 0;
        _ball = Resources.Load<GameObject>("Prefabs/Ball");

        InvokeRepeating(nameof(MakeBall), 2.0f, 3.0f);
        InvokeRepeating(nameof(SpawnApple), 10.0f, 20.0f);

        Characters[DataManager.Instance.CharacterNum].SetActive(true);
    }

    private void Update()
    {
        if (!IsGamePlaying) return;
        CurrentScoreTxt.text = Instance.Score.ToString();
    }

    private void MakeBall()
    {
        Instantiate(Instance._ball);
    }

    private void SpawnApple()
    {
        var x = Random.Range(-3.0f, 3.0f);
        const float y = 10.0f;
        Instantiate(Apple, new Vector2(x, y), Quaternion.identity);
    }

    public void GameOver()
    {
        IsGamePlaying = false;
        GameOverModal.SetActive(true);
        TimeManager.Instance.TimeText.text = "";

        BestScoreTxt.text = BestScore.ToString();
        if (Instance.Score > BestScore)
        {
            BestScore = Instance.Score;
            BestScoreTxt.text = BestScore.ToString();
        }
        Instance.CurrentScoreTxt.text = "";
        Instance.BestScoreTxt.text = "";

        BestScoreResult.text = "최고 점수: " + BestScore;
        CurrentScoreResult.text = "획득 점수: " + Instance.Score;
        Time.timeScale = 0;
    }
}