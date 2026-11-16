using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float timeValue = 180f;
    public Text timeText;

    private void Update()
    {
        if (timeText == null || Time.timeScale == 0f)
        {
            return;
        }

        timeValue = Mathf.Max(0f, timeValue - Time.deltaTime);
        DisplayTime(timeValue);

        if (timeValue == 0f)
        {
            Object.FindFirstObjectByType<GameManager>().ShowResult("You survived!");
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        int totalSeconds = Mathf.CeilToInt(timeToDisplay);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}