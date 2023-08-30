using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    
    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    
    private void UpdateScoreText()
    {
        scoreText.text = "Coins: " + score.ToString();
    }
}

