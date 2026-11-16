using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void TriggerGameOVer()
    {
        ShowResult("Game Over!");
    }

    public void ShowResult(string message)
    {
        resultText.text = message;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}   