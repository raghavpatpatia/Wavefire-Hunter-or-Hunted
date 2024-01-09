using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public event Action shoot;
    public event Action OnEnemyDeath;
    public event Action ActivateGameOverPanel;
    public event Action DeactivateGameOverPanel;
    public event Action ActivatePausePanel;
    public event Action DeactivatePausePanel;
    public event Action<int> UpdateScore;
    public event Action ActivateReloadingText;
    public event Action DeactivateReloadText;
    public event Action<int> SetWave;
    public event Action<string> GameOverText;
    public event Action OnReset;

    public void InvokeShoot()
    {
        shoot?.Invoke();
    }
    public void InvokeOnDeath()
    {
        OnEnemyDeath?.Invoke();
    }

    public void InvokeUpdateScore(int score)
    {
        UpdateScore?.Invoke(score);
    }

    public void InvokeActivateReloadText()
    {
        ActivateReloadingText?.Invoke();
    }
    public void InvokeDeactivateReloadText()
    {
        DeactivateReloadText?.Invoke();
    }
    public void InvokeSetWave(int waveNumber)
    {
        SetWave?.Invoke(waveNumber);
    }
    public void InvokeGameOverText(string Text)
    {
        GameOverText?.Invoke(Text);
    }
    public void InvokeOnReset()
    {
        OnReset?.Invoke();
    }

    public void InvokeActivateGameOverPanel()
    {
        ActivateGameOverPanel?.Invoke();
    }
    public void InvokeDeactivateGameOverPanel()
    {
        DeactivateGameOverPanel?.Invoke();
    }

    public void InvokeActivatePausePanel()
    {
        ActivatePausePanel?.Invoke();
    }
    public void InvokeDeactivatePausePanel()
    {
        DeactivatePausePanel?.Invoke();
    }
}