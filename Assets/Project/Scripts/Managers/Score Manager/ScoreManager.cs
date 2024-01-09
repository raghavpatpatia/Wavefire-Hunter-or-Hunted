using UnityEngine;

public class ScoreManager : NonMonoSingleton<ScoreManager>
{
    private int currentScore;
    private int highScore;
    public ScoreManager() : base() { }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") >= highScore)
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        return highScore;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void SetScore(int value)
    {
        currentScore += value;
        if (currentScore > highScore) 
        { 
            highScore = currentScore;
        }
    }
}