using System.Collections;
using UnityEngine;
public class AttackingState : EnemyStateMachine
{
    private float blinkDuration;
    private float blinkInterval;
    private MeshRenderer enemyMeshRenderer;
    private Coroutine attackMaterialCoroutine;
    public AttackingState(EnemyController enemyController) : base(enemyController) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyState = EnemyStatesEnum.Attacking;
        blinkDuration = enemyController.enemyModel.timeBetweenMaterialChange;
        blinkInterval = 0.2f;
    }

    public override void Tick()
    {
        base.Tick();
        AttackMaterialChange();
        enemyController.ChangeState(EnemyStatesEnum.Chasing);
    }

    private void AttackMaterialChange()
    {
        if (attackMaterialCoroutine != null)
        {
            enemyController.enemyView.StopCoroutine(attackMaterialCoroutine);
        }
        attackMaterialCoroutine = enemyController.enemyView.StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial()
    {
        float elapsedBlinkTime = 0f;

        while (elapsedBlinkTime < blinkDuration)
        {
            if (enemyController.enemyView.gameObject.TryGetComponent<MeshRenderer>(out enemyMeshRenderer))
            {
                enemyMeshRenderer.material = enemyController.enemyModel.defaultMaterial;
                yield return new WaitForSeconds(blinkInterval);
                enemyMeshRenderer.material = enemyController.enemyModel.bombTriggerMaterial;
                yield return new WaitForSeconds(blinkInterval);
            }
            elapsedBlinkTime += blinkInterval * 2;
        }
        if (enemyController.enemyView.gameObject.TryGetComponent<MeshRenderer>(out enemyMeshRenderer))
        {
            enemyMeshRenderer.material = enemyController.enemyModel.defaultMaterial;
        }
    }


    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}