using System.Collections;
using UnityEngine;

public class GunController
{
    public GunModel gunModel { get; }
    public GunView gunView { get; }
    private int bulletCount;
    private float nextShootTime;
    public GunController(GunScriptableobject gunScriptableObject, Transform gunSpawnPoint)
    {
        // GunModel
        gunModel = new GunModel(gunScriptableObject);
        gunModel.SetGunController(this);
        // GunView
        gunView = GameObject.Instantiate<GunView>(gunScriptableObject.gunView, gunSpawnPoint);
        gunView.SetGunController(this);
        // Other Initializations
        bulletCount = 0;
    }

    public void Shoot(Transform bulletSpawnPoint)
    {
        if (bulletCount <= gunModel.maximumBulletRange)
        {
            if (Time.time > nextShootTime)
            {
                nextShootTime = Time.time + gunModel.timeBetweenShooting / 1000;
                BulletService.Instance.FireBullet(gunModel.bullet, bulletSpawnPoint);
                bulletCount++;
            }
        }
        else if (bulletCount > gunModel.maximumBulletRange)
        {
            gunView.StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        EventManager.Instance.InvokeActivateReloadText();
        yield return new WaitForSeconds(gunModel.reloadTime);
        bulletCount = 0;
        EventManager.Instance.InvokeDeactivateReloadText();
    }
}