using UnityEngine;

public class EnemyController
{
    public EnemyModel enemyModel { get; private set; }
    public EnemyView enemyView { get; private set; }
    public EnemyStateMachine enemyStateMachine { get; private set; }
    private MeshRenderer enemyMaterial;
    private float defaultHealth;
    private float currentHealth;
    public EnemyController(EnemyScriptableObject scriptableObject)
    {
        // EnemyModel
        enemyModel = new EnemyModel(scriptableObject);
        enemyModel.SetEnemyController(this);
        // EnemyView
        enemyView = GameObject.Instantiate<EnemyView>(scriptableObject.enemyView, new Vector3(Random.Range(-enemyModel.spawnPosition.x, enemyModel.spawnPosition.x), 0, Random.Range(-enemyModel.spawnPosition.y, enemyModel.spawnPosition.y)), Quaternion.identity);
        enemyView.SetEnemyController(this);
        // Other Initializations
        enemyStateMachine = new EnemyStateMachine(this);
        currentHealth = enemyModel.currentHealth;
        defaultHealth = currentHealth;
    }
    public void EnemyStateMachineTick()
    {
        if (enemyStateMachine != null)
        {
            enemyStateMachine.Tick();
        }
    }
    public void ChangeState(EnemyStatesEnum state)
    {
        if (enemyStateMachine != null)
        {
            enemyStateMachine.OnStateExit();
        }
        switch (state)
        {
            case EnemyStatesEnum.Idle:
                enemyStateMachine = new IdleState(this);
                break;
            case EnemyStatesEnum.Chasing:
                enemyStateMachine = new ChasingState(this);
                break;
            case EnemyStatesEnum.Attacking:
                enemyStateMachine = new AttackingState(this);
                break;
        }
        enemyStateMachine.OnStateEnter();
    }

    public void OnCollision(Collision colllision)
    {
        IDamageable damageable = colllision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(enemyModel.damage);
            ChangeState(EnemyStatesEnum.Attacking);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyView.healthBar.UpdateHealthBar(currentHealth, defaultHealth);
        if (currentHealth <= 0)
        {
            EnemyService.Instance.ReturnEnemy(this);
        }
    }

    public void OnEnable()
    {
        enemyView.rb = enemyView.GetComponent<Rigidbody>();
        enemyView.rb.position = new Vector3(Random.Range(-enemyModel.spawnPosition.x, enemyModel.spawnPosition.x), 0, Random.Range(-enemyModel.spawnPosition.y, enemyModel.spawnPosition.y));
        enemyView.rb.rotation = Quaternion.identity;
        currentHealth = defaultHealth;
        enemyView.healthBar.UpdateHealthBar(currentHealth, defaultHealth);
        ChangeState(EnemyStatesEnum.Idle);
        if (enemyView.gameObject.TryGetComponent<MeshRenderer>(out enemyMaterial))
        {
            enemyMaterial.material = enemyModel.defaultMaterial;
        }
        enemyView.gameObject.SetActive(true);
    }
    
    public void OnDisable()
    {
        enemyView.rb.position = Vector3.zero;
        enemyView.rb.rotation = Quaternion.identity;
        enemyView.gameObject.SetActive(false);
        EventManager.Instance.InvokeOnDeath();
        EventManager.Instance.InvokeUpdateScore(enemyModel.enemyScore);
    }
}