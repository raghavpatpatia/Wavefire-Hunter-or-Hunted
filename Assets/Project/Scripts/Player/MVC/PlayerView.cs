using UnityEngine;

public class PlayerView : MonoBehaviour, IDamageable
{
    [SerializeField] public Transform gunSpawnPoint;
    [SerializeField] public HealthBar healthBar;
    public PlayerController playerController { get; private set; }
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        playerController.PlayerLookAt();
        playerController.Shoot();
    }
    private void FixedUpdate()
    {
        playerController.Move();
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void TakeDamage(int damage)
    {
        playerController.TakeDamage(damage);
    }
}
