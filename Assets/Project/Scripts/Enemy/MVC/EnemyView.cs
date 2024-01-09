using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class EnemyView : MonoBehaviour, IDamageable
{
    public EnemyController enemyController { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public Rigidbody rb { get; set; }
    [SerializeField] public HealthBar healthBar;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        enemyController.EnemyStateMachineTick();
    }
    public void SetEnemyController(EnemyController enemyController) { this.enemyController = enemyController; }

    private void OnCollisionEnter(Collision collision)
    {
        enemyController.OnCollision(collision);
    }

    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }
}