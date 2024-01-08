using UnityEngine;

public class MapModel
{
    public MapController mapController { get; private set; }
    public Transform tilePrefab { get; private set; }
    public Transform obstaclePrefab { get; private set; }
    public Vector2 mapSize { get; private set; }
    public float outlinePercent { get; private set; }
    public int seed { get; private set; }
    public float obstaclePercent { get; private set; }
    public MapModel(MapScriptableObject map) 
    {
        tilePrefab = map.tilePrefab;
        obstaclePrefab = map.obstaclePrefab;
        mapSize = map.mapSize;
        outlinePercent = map.outlinePercent;
        seed = map.seed;
        obstaclePercent = map.obstaclePercent;
    }
    public void SetMapController(MapController mapController)
    {
        this.mapController = mapController;
    }
}