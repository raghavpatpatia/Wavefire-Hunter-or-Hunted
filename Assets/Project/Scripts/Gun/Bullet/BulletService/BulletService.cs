using UnityEngine;

public class BulletService : NonMonoSingleton<BulletService>
{
    private BulletObjectPooler bulletObjectPooler;
    private BulletController bulletController;
    public Transform transform;
    public BulletService() : base()
    {
        bulletObjectPooler = new BulletObjectPooler();
    }
    public void FireBullet(BulletScriptableObject bullet, Transform bulletSpawnPoint)
    {
        this.transform = bulletSpawnPoint;
        bulletController = bulletObjectPooler.GetBullet(bullet);
        bulletController.OnEnable(bulletSpawnPoint);
    }

    public void ReturnBullet(BulletController bulletController)
    {
        bulletController.OnDisable();
        bulletObjectPooler.ReturnItem(bulletController);
    }
}