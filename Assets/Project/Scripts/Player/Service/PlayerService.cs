using UnityEngine;
public class PlayerService : NonMonoSingleton<PlayerService>
{
    public PlayerScriptableObject playerScriptableObject;
    public GunScriptableobject gunScriptableobject;
    public Camera viewCamera;
    private PlayerController playerController;
    public PlayerService() : base()
    {
        playerScriptableObject = GameSceneManager.Instance.playerScriptableObject;
        gunScriptableobject = GameSceneManager.Instance.gunScriptableobject;
        viewCamera = GameSceneManager.Instance.viewCamera;
    }
    public void InitializePlayer()
    {
        playerController = new PlayerController(playerScriptableObject);
        playerController.OnEnable();
    }
    public Transform GetPlayerTransform()
    {
        return playerController.GetPlayerTransform();
    }

    public void ResetPlayer()
    {
        playerController.playerView.gameObject.SetActive(false);
        playerController.OnEnable();
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}