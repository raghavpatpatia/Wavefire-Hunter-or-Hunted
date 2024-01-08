using System.Collections;
using UnityEngine;

public class BulletController
{
    public BulletView bulletView { get; private set; }
    public BulletModel bulletModel { get; private set; }
    public BulletCollisions bulletCollisions { get; private set; }
    private Coroutine returnBulletCoroutine;
    public BulletController(BulletScriptableObject scriptableObject)
    {
        // Bullet Model
        bulletModel = new BulletModel(scriptableObject);
        bulletModel.SetBulletController(this);
        // Bullet View
        bulletView = GameObject.Instantiate<BulletView>(scriptableObject.bulletView, BulletService.Instance.transform.position, Quaternion.identity);
        bulletView.SetBulletController(this);
        DetachFromAllParents();
        // BulletCollisions
        bulletCollisions = new BulletCollisions(this);
    }
    public void DetachFromAllParents()
    {
        Transform transform = bulletView.transform;
        while (transform.parent != null)
        {
            transform.SetParent(null);
        }
    }
    private void MoveBullet()
    {
        bulletView.rb.AddForce(bulletView.rb.transform.forward * bulletModel.bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }
    public void OnEnable(Transform bulletSpawnPoint)
    {
        bulletView.rb.transform.position = bulletSpawnPoint.position;
        bulletView.rb.transform.rotation = bulletSpawnPoint.rotation;
        bulletView.gameObject.SetActive(true);
        MoveBullet();
        ReturnBulletCoroutine();
    }
    public void OnDisable()
    {
        bulletView.rb.velocity = Vector3.zero;
        bulletView.rb.angularVelocity = Vector3.zero;
        bulletView.rb.transform.rotation = Quaternion.identity;
        bulletView.gameObject.SetActive(false);
    }
    private void ReturnBulletCoroutine()
    {
        if (returnBulletCoroutine != null)
        {
            bulletView.StopCoroutine(returnBulletCoroutine);
        }
        returnBulletCoroutine = bulletView.StartCoroutine(ReturnBullet(bulletModel.maxEnableTime));
    }
    private IEnumerator ReturnBullet(float time)
    {
        yield return new WaitForSeconds(time);
        BulletService.Instance.ReturnBullet(this);
    }
}