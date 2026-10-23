using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    private ScoreUI scoreUI;

    private int score;
    public int Score
    {
        get { return score; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameSession.Instance != null)
        {
            score = GameSession.Instance.Score;
        }
        UpdateUI();
        if (PersistentGameManager.Instance != null)
        {
            PersistentGameManager.Instance.UpdateHighScore(score);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(10);
        }
    }

    public void AddScore(int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        score += amount;
        SetScore(score + amount);
    }

    private void UpdateUI()
    {
        if (scoreUI != null)
        {
            scoreUI.SetScore(score);
        }
    }

    public void SetScore(int value)
    {
        score = Mathf.Max(value, 0);
        if (GameSession.Instance != null)
        {
            GameSession.Instance.Score = score;
        }
        if (PersistentGameManager.Instance != null)
        {
            PersistentGameManager.Instance.UpdateHighScore(score);
        }
        UpdateUI();
    }
}
