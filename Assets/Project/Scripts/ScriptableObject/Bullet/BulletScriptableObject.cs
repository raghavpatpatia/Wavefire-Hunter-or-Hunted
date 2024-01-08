using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/Bullet/BulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletView bulletView;
    public float bulletSpeed;
    public int bulletDamage;
    public float maxEnableTime;
}