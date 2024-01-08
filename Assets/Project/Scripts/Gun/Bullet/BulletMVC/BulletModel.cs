public class BulletModel
{
    public BulletController bulletController { get; private set; }
    public float bulletSpeed { get; private set; }
    public float maxEnableTime { get; private set; }
    public int bulletDamage { get; private set; }
    public BulletModel(BulletScriptableObject scriptableObject)
    {
        this.bulletSpeed = scriptableObject.bulletSpeed;
        this.bulletDamage = scriptableObject.bulletDamage;
        this.maxEnableTime = scriptableObject.maxEnableTime;
    }
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}