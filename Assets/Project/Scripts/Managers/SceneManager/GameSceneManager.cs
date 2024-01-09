using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : Singleton<GameSceneManager>
{
    [Header("Player Service")]
    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    [SerializeField] public GunScriptableobject gunScriptableobject;
    [SerializeField] public Camera viewCamera;
    private PlayerService playerService;
    [Header("Enemy Service")]
    [SerializeField] public EnemyScriptableObject enemyScriptableObject;
    private EnemyService enemyService;
    // Other Instances
    private BulletService bulletService;
    private ScoreManager scoreManager;
    protected override void Awake()
    {
        base.Awake();
        scoreManager = new ScoreManager();
        bulletService = new BulletService();
        playerService = new PlayerService();
        enemyService = new EnemyService();
    }
}