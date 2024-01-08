public class EnemyObjectPooler : GenericObjectPooler<EnemyController>
{
    private EnemyScriptableObject enemyScriptableObject;
    public EnemyController GetEnemy(EnemyScriptableObject enemyScriptableObject)
    {
        this.enemyScriptableObject = enemyScriptableObject;
        return GetItem();
    }
    public override EnemyController CreateItem()
    {
        EnemyController enemyController = new EnemyController(enemyScriptableObject);
        return enemyController;
    }
}