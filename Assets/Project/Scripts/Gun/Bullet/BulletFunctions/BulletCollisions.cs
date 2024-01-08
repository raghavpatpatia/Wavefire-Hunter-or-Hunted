using UnityEngine;

public class BulletCollisions
{
    private BulletController bulletController;
    public BulletCollisions(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public void OnCollision(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(bulletController.bulletModel.bulletDamage);
        }
        BulletService.Instance.ReturnBullet(bulletController);
    }
}