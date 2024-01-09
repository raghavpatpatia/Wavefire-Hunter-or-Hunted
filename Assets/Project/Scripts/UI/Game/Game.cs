using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI reloadingText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [Header("Panel")]
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PausePanel;

    public void OnEnable()
    {
        EventManager.Instance.UpdateScore += UpdateScore;
        EventManager.Instance.ActivateReloadingText += SetReloadingText;
        EventManager.Instance.DeactivateReloadText += DisableReloadingText;
        EventManager.Instance.SetWave += Wave;
        EventManager.Instance.GameOverText += GameoverText;
        EventManager.Instance.ActivateGameOverPanel += ActivatePanel;
        EventManager.Instance.DeactivateGameOverPanel += DeactivatePanel;
        EventManager.Instance.ActivatePausePanel += ActivatePausePanel;
        EventManager.Instance.DeactivatePausePanel += DeactivatePausePanel;
    }

    private void Start()
    {
        scoreText.text = string.Format("Score: {0}", ScoreManager.Instance.GetCurrentScore());
        highScore.text = string.Format("HighScore: {0}", ScoreManager.Instance.GetHighScore());
    }

    private void UpdateScore(int points)
    {
        ScoreManager.Instance.SetScore(points);
        scoreText.text = string.Format("Score: {0}", ScoreManager.Instance.GetCurrentScore());
        highScore.text = string.Format("HighScore: {0}", ScoreManager.Instance.GetHighScore());
    }

    private void SetReloadingText()
    {
        reloadingText.text = "Reloading..";
        reloadingText.gameObject.SetActive(true);
    }

    private void DisableReloadingText()
    {
        reloadingText.text = "";
        reloadingText.gameObject.SetActive(false);
    }

    private void Wave(int waveNumber)
    {
        waveText.text = string.Format("Wave: {0}", waveNumber);
    }

    private void GameoverText(string text)
    {
        gameOverText.text = text;
    }

    private void ActivatePanel() 
    { 
        GameOverPanel.SetActive(true);
    }
    private void DeactivatePanel() 
    {
        GameOverPanel.SetActive(false);
    }
    private void ActivatePausePanel() 
    { 
        PausePanel.SetActive(true);
    }
    private void DeactivatePausePanel() 
    { 
        PausePanel.SetActive(false);
    }
    public void OnDisable()
    {
        EventManager.Instance.UpdateScore -= UpdateScore;
        EventManager.Instance.ActivateReloadingText -= SetReloadingText;
        EventManager.Instance.DeactivateReloadText -= DisableReloadingText;
        EventManager.Instance.SetWave -= Wave;
        EventManager.Instance.GameOverText -= GameoverText;
        EventManager.Instance.ActivateGameOverPanel -= ActivatePanel;
        EventManager.Instance.DeactivateGameOverPanel -= DeactivatePanel;
        EventManager.Instance.ActivatePausePanel -= ActivatePausePanel;
        EventManager.Instance.DeactivatePausePanel -= DeactivatePausePanel;
    }
}