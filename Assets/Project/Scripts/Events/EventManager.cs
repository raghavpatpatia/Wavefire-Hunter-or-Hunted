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
    public void InvokeShoot()
    {
        shoot?.Invoke();
    }
    public void InvokeOnDeath()
    {
        OnEnemyDeath?.Invoke();
    }
}