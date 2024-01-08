using UnityEngine;

public class GunView : MonoBehaviour
{
    public GunController gunController { get; private set; }
    [SerializeField] private Transform bulletSpawnPoint;
    private void OnEnable()
    {
        EventManager.Instance.shoot += Shoot;
    }
    public void SetGunController(GunController gunController)
    {
        this.gunController = gunController;
    }

    private void Shoot()
    {
        gunController.Shoot(bulletSpawnPoint);
    }

    private void OnDisable()
    {
        EventManager.Instance.shoot -= Shoot;
    }
}