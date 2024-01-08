using UnityEngine;

public class BulletObjectPooler : GenericObjectPooler<BulletController>
{
    private BulletScriptableObject bullet;
    public BulletController GetBullet(BulletScriptableObject bullet)
    {
        this.bullet = bullet;
        return GetItem();
    }
    public override BulletController CreateItem()
    {
        BulletController bulletController = new BulletController(bullet);
        return bulletController;
    }
}