﻿using UnityEngine;

public class EnemyService : NonMonoSingleton<EnemyService>
{
    private EnemyObjectPooler enemyObjectPooler;
    private EnemyController enemyController;
    public EnemyService() : base()
    {
        enemyObjectPooler = new EnemyObjectPooler();
    }
    public void GetEnemy(EnemyScriptableObject enemyScriptableObject)
    {
        enemyController = enemyObjectPooler.GetEnemy(enemyScriptableObject);
        enemyController.OnEnable();
    }

    public void ReturnEnemy(EnemyController enemyController)
    {
        enemyController.OnDisable();
        enemyObjectPooler.ReturnItem(enemyController);
    }
}