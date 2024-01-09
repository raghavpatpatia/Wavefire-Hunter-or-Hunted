using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ChangeSceneButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private int sceneIndex;
    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        PlayerPrefs.SetInt("HighScore", ScoreManager.Instance.GetHighScore());
        ScoreManager.Instance.ResetCurrentScore();
        EventManager.Instance.InvokeUpdateScore(0);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
        EventManager.Instance.InvokeDeactivateGameOverPanel();
        EventManager.Instance.InvokeDeactivatePausePanel();
    }
}