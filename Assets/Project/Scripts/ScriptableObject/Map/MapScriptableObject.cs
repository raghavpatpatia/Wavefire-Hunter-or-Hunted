using UnityEngine;

[CreateAssetMenu(fileName = "MapScriptableObject", menuName = "ScriptableObjects/Map/MapScriptableObject")]
public class MapScriptableObject : ScriptableObject
{
    public Transform tilePrefab;
    public Transform obstaclePrefab;
    public Vector2 mapSize;
    [Range(0, 1)] public float outlinePercent;
    [Range(0, 1)] public float obstaclePercent;
    public int seed;
}