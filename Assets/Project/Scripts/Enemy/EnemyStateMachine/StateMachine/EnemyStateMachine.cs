using UnityEngine;

public class EnemyStateMachine
{
    protected EnemyController enemyController;
    protected EnemyStatesEnum enemyState;
    protected float playerDistance;
    public EnemyStateMachine(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
    public virtual void OnStateEnter() { }
    public virtual void Tick() 
    {
        UpdatePlayerDistance();
    }
    private void UpdatePlayerDistance()
    {
        if (PlayerService.Instance.GetPlayerController().playerView.gameObject.activeSelf == false)
        {
            enemyController.enemyView.agent.ResetPath();
            enemyController.enemyView.rb.velocity = Vector3.zero;
        }
        else
        {
            playerDistance = GetPlayerDistance();
        }
    }

    private float GetPlayerDistance()
    {
        Vector3 playerPosition = PlayerService.Instance.GetPlayerTransform().position;
        Vector3 enemyPosition = enemyController.enemyView.rb.position;
        return (playerPosition - enemyPosition).sqrMagnitude;
    }

    public virtual void OnStateExit() { }
}