using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResumeButton : MonoBehaviour
{
    private Button resumeButton;

    public void Start()
    {
        resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        EventManager.Instance.InvokeDeactivatePausePanel();
    }
}