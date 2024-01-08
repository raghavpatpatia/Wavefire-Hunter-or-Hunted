public class PlayerModel
{
    public PlayerController playerController { get; private set; }
    public float moveSpeed { get; private set; }
    public float health { get; private set; }
    public PlayerModel(PlayerScriptableObject scriptableObject)
    {
        moveSpeed = scriptableObject.moveSpeed;
        health = scriptableObject.health;
    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }
}