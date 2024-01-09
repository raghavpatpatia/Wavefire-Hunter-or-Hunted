using UnityEngine;

public class PlayerController
{
    public PlayerModel playerModel { get; private set; }
    public PlayerView playerView { get; private set; }
    public GunController gunController { get; set; }
    private GunHandeler gunHandeler;
    private Camera viewCamera;
    private float currentHealth;
    private float defaultHealth;
    public PlayerController(PlayerScriptableObject scriptableObject)
    {
        // PlayerModel
        playerModel = new PlayerModel(scriptableObject);
        playerModel.SetPlayerController(this);
        // PlayerView
        playerView = GameObject.Instantiate<PlayerView>(scriptableObject.playerView, new Vector3(Random.Range(-playerModel.spawnPosition.x, playerModel.spawnPosition.x), 1.0f, Random.Range(-playerModel.spawnPosition.y, playerModel.spawnPosition.y)), Quaternion.identity);
        playerView.SetPlayerController(this);
        // GunHandeler
        gunHandeler = new GunHandeler(this);
        // Other Initializations
        // Set Gun
        gunHandeler.InstantiateGun(PlayerService.Instance.gunScriptableobject);
        // Set Camera 
        viewCamera = PlayerService.Instance.viewCamera;
        viewCamera = Camera.main;
        // Health
        currentHealth = playerModel.health;
        defaultHealth = currentHealth;
    }
    public void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * playerModel.moveSpeed;
        playerView.GetRigidbody().MovePosition(playerView.GetRigidbody().position + moveVelocity * Time.deltaTime);
    }

    public void PlayerLookAt()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 yOffsetPoint = new Vector3(point.x, playerView.transform.position.y, point.z);
            playerView.transform.LookAt(yOffsetPoint);
        }
    }

    public void Shoot()
    {
        gunHandeler.ShootBullets();
    }

    public Transform GetPlayerTransform()
    {
        return playerView.GetRigidbody().transform;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerView.healthBar.UpdateHealthBar(currentHealth, defaultHealth);
        if (currentHealth <= 0)
        {
            OnDisable();
        }
    }

    public  void OnEnable()
    {
        playerView.transform.position = new Vector3(Random.Range(-playerModel.spawnPosition.x, playerModel.spawnPosition.x), 1.0f, Random.Range(-playerModel.spawnPosition.y, playerModel.spawnPosition.y));
        playerView.transform.rotation = Quaternion.identity;
        currentHealth = defaultHealth;
        playerView.healthBar.UpdateHealthBar(currentHealth, defaultHealth);
        playerView.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        playerView.gameObject.SetActive(false);
        EventManager.Instance.InvokeGameOverText("Player Lost!!");
        EventManager.Instance.InvokeActivateGameOverPanel();
    }
}