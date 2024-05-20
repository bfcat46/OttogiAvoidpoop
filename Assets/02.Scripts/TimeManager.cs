using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private const float GAME_TIME_MINUTES = 5;
    
    public TextMeshProUGUI TimeText;

    private static TimeManager s_instance;
    public static TimeManager Instance => s_instance == null ? null : s_instance;
    
    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(Instance.Timer());
    }

    public IEnumerator Timer()
    {
        var elapsedTime = GAME_TIME_MINUTES * 60.0f;
        while (elapsedTime > 0.0f)
        {
            elapsedTime -= Time.deltaTime;
            var minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
            var seconds = Mathf.Floor(elapsedTime % 60).ToString("00");
            TimeText.text = $"{minutes}:{seconds}";
            yield return null;
        }
        GameManager.Instance.GameOver();
    }
}