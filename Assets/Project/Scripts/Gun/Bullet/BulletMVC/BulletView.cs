using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletView : MonoBehaviour
{
    public BulletController bulletController { get; private set; }
    public Rigidbody rb { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;  
    }
    private void OnCollisionEnter(Collision collision)
    {
        bulletController.bulletCollisions.OnCollision(collision);
    }
}