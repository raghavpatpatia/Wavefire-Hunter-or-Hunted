public class GunModel
{
    public GunController gunController { get; private set; }
    public BulletScriptableObject bullet { get; }
    public int maximumBulletRange { get; }
    public float timeBetweenShooting { get; }
    public float reloadTime { get; }

    public GunModel(GunScriptableobject gunScriptableObject)
    {
        bullet = gunScriptableObject.bullet;
        maximumBulletRange = gunScriptableObject.maximumBulletRange;
        timeBetweenShooting = gunScriptableObject.timeBetweenShooting;
        reloadTime = gunScriptableObject.reloadTime;
    }

    public void SetGunController(GunController gunController)
    {
        this.gunController = gunController;
    }
}