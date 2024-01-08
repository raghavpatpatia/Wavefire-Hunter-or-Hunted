using UnityEngine;

public class GunHandeler
{
    public PlayerController playerController { get; private set; }
    public GunHandeler(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public void InstantiateGun(GunScriptableobject gunScriptableObject)
    {
       if (playerController.gunController != null)
       {
            GameObject.Destroy(playerController.gunController.gunView);
       }
       playerController.gunController = new GunController(gunScriptableObject, playerController.playerView.gunSpawnPoint);
    }

    public void ShootBullets()
    {
        if (Input.GetMouseButton(0))
        {
            EventManager.Instance.InvokeShoot();
        }
    }
}