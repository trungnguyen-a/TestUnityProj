using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private TextMeshProUGUI finalScoreText;

    private GameScore gameScore;
    private bool isGameOver;
    private bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        isPaused = false;
        // GameSession.Instance.ResetSession();
        gameScore = GetComponent<GameScore>();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        isPaused = false;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = "FINAL SCORE: " + gameScore.Score;
        }
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 0f;
    }

    public void GameRestart()
    {
        Time.timeScale = 1f;
        if (GameSession.Instance != null)
        {
            GameSession.Instance.ResetSession();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PauseGame()
    {
        if (isGameOver || isPaused) return;
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        if (isGameOver || !isPaused) return;
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}
