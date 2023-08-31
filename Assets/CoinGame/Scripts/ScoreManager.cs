using UnityEngine;
using TMPro;

/// <summary>
/// Manages the game's score and updates the score UI.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshPro Text element in the UI for displaying the score.
    /// </summary>
    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    /// <summary>
    /// Updates the score by adding the given number of points and refreshes the UI.
    /// </summary>
    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    /// <summary>
    /// Updates the Text element with the current score.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Coins: " + score.ToString();
    }
}
