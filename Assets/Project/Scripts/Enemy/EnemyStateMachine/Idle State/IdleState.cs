using UnityEngine;
public class IdleState : EnemyStateMachine
{
    private float idleTimer;
    public IdleState(EnemyController enemyController) : base(enemyController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyState = EnemyStatesEnum.Idle;
        idleTimer = enemyController.enemyModel.idleDuration;
    }
    public override void Tick()
    {
        base.Tick();
        ChangeState();
    }

    private void ChangeState()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            enemyController.ChangeState(EnemyStatesEnum.Chasing);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}