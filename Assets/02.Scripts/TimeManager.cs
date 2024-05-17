using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text Text;

    IEnumerator Timer()
    {
        var elapsedTime = 0.0f;
        while (elapsedTime <= 300.0f)
        {
            elapsedTime += Time.deltaTime;
            var minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
            var seconds = (elapsedTime % 60).ToString("00");
            Text.text = $"{minutes}:{seconds}";
            yield return null;
        }
    }
}