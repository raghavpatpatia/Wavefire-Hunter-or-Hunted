using System.Collections.Generic;

public class EnemyObjectPooler : GenericObjectPooler<EnemyController>
{
    private EnemyScriptableObject enemyScriptableObject;
    public List<EnemyController> enemyControllerList = new List<EnemyController>();
    public EnemyController GetEnemy(EnemyScriptableObject enemyScriptableObject)
    {
        this.enemyScriptableObject = enemyScriptableObject;
        return GetItem();
    }
    public override EnemyController CreateItem()
    {
        EnemyController enemyController = new EnemyController(enemyScriptableObject);
        enemyControllerList.Add(enemyController);
        return enemyController;
    }
}