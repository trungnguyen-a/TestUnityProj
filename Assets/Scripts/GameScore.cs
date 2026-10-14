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
        UpdateUI();
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
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreUI != null)
        {
            scoreUI.SetScore(score);
        }
    }
}
