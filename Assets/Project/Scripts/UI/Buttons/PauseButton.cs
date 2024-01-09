using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    private Button pauseButton;

    public void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        EventManager.Instance.InvokeActivatePausePanel();
    }
}