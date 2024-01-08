using UnityEngine;

public class GameSceneManager : Singleton<GameSceneManager>
{
    [Header("Player Service")]
    private PlayerService playerService;
    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    [SerializeField] public GunScriptableobject gunScriptableobject;
    [SerializeField] public Camera viewCamera;
    [Header("Enemy Service")]
    private EnemyService enemyService;
    [SerializeField] public EnemyScriptableObject enemyScriptableObject;

    private BulletService bulletService;
    protected override void Awake()
    {
        base.Awake();
        bulletService = new BulletService();
        playerService = new PlayerService();
        enemyService = new EnemyService();
    }
}