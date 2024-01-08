using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public float health;
    public PlayerView playerView;
}