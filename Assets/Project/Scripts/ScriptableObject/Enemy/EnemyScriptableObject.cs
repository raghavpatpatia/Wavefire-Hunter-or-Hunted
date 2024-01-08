using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public Vector2Int spawnPosition;
    public EnemyView enemyView;
    public Material defaultMaterial;
    public Material bombTriggerMaterial;
    public float timeBetweenMaterialChange;
    public float moveSpeed;
    public float health;
    public int damage;
    public float idleDuration;
    public float refreshTimerChaseState;
}