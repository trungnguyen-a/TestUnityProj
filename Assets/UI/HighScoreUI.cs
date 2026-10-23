using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int highScore = 0;
        if (PersistentGameManager.Instance != null)
        {
            highScore = PersistentGameManager.Instance.HighScore;
        }
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
