﻿using UnityEngine;

public class ChasingState : EnemyStateMachine
{
    private float refreshTimer;
    private float timer;

    public ChasingState(EnemyController enemyController) : base(enemyController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyState = EnemyStatesEnum.Chasing;
        refreshTimer = enemyController.enemyModel.refreshTimerChaseState;
        timer = refreshTimer;
    }

    public override void Tick()
    {
        base.Tick();
        UpdateState();
    }

    private void UpdateState()
    {
        if (PlayerService.Instance.GetPlayerController().playerView.gameObject.activeSelf != false)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        enemyController.enemyView.transform.LookAt(PlayerService.Instance.GetPlayerTransform().position);
        timer -= Time.deltaTime;
        if (timer < 0 && enemyController.enemyView.agent.isActiveAndEnabled)
        {
            enemyController.enemyView.agent.SetDestination(PlayerService.Instance.GetPlayerTransform().position);
            timer = refreshTimer;
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
