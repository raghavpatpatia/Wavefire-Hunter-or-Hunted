using UnityEngine;

public class EnemyModel
{
    public EnemyController enemyController { get; private set; }
    public Vector2Int spawnPosition { get; private set; }
    public float moveSpeed { get; private set; }
    public float currentHealth { get; private set; }
    public int damage { get; private set; }
    public float idleDuration { get; private set; }
    public float refreshTimerChaseState { get; private set; }
    public Material defaultMaterial { get; private set; }
    public Material bombTriggerMaterial { get; private set; }
    public float timeBetweenMaterialChange { get; private set; }
    public void SetEnemyController(EnemyController enemyController) { this.enemyController = enemyController; }
    public EnemyModel(EnemyScriptableObject scriptableObject) 
    {
        moveSpeed = scriptableObject.moveSpeed;
        currentHealth = scriptableObject.health;
        damage = scriptableObject.damage; 
        spawnPosition = scriptableObject.spawnPosition;
        idleDuration = scriptableObject.idleDuration;
        refreshTimerChaseState = scriptableObject.refreshTimerChaseState;
        defaultMaterial = scriptableObject.defaultMaterial;
        bombTriggerMaterial = scriptableObject.bombTriggerMaterial;
        timeBetweenMaterialChange = scriptableObject.timeBetweenMaterialChange;
    }
}
