using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button restartButton;

    public void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        Time.timeScale = 1;
        EventManager.Instance.InvokeOnReset();
        ScoreManager.Instance.ResetCurrentScore();
        EventManager.Instance.InvokeUpdateScore(0);
        EventManager.Instance.InvokeDeactivateGameOverPanel();
        EventManager.Instance.InvokeDeactivatePausePanel();
    }
}