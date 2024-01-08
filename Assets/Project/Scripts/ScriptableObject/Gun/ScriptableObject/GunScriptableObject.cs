using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "ScriptableObjects/Gun/ScriptableObject/GunScriptableObject")]
public class GunScriptableobject : ScriptableObject
{
    public GunView gunView;
    public BulletScriptableObject bullet;
    public int maximumBulletRange;
    public float timeBetweenShooting;
    public float reloadTime;
}