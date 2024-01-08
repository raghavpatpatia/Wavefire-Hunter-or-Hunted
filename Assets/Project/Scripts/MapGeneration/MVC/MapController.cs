using System.Collections.Generic;
using UnityEngine;

public class MapController
{
    public MapModel mapModel { get; private set; }
    public MapView mapView { get; private set; }
    private List<Coordinates> allTileCoords;
    private Queue<Coordinates> shuffledTileCoords;
    private Coordinates mapCentre;
    public MapController(MapScriptableObject map, MapView mapView) 
    {
        // Map Model
        mapModel = new MapModel(map);
        mapModel.SetMapController(this);
        // Map View
        this.mapView = mapView;
        mapView.SetMapController(this);
        // Other Initializations
        GenerateMap(mapView);
    }

    private void GenerateMap(MapView mapView)
    {
        allTileCoords = new List<Coordinates>();
        for (int x = 0; x < mapModel.mapSize.x; x++)
        {
            for (int y = 0; y < mapModel.mapSize.y; y++)
            {
                allTileCoords.Add(new Coordinates(x, y));
            }
        }

        shuffledTileCoords = new Queue<Coordinates>(Utiity.ShuffleArray(allTileCoords.ToArray(), mapModel.seed));
        mapCentre = new Coordinates((int)mapModel.mapSize.x / 2, (int)mapModel.mapSize.y / 2);

        for (int x = 0; x < mapModel.mapSize.x; x++)
        {
            for (int y = 0; y < mapModel.mapSize.y; y++)
            {
                Vector3 tilePosition = CoordinatePosition(x, y);
                Transform newTile = GameObject.Instantiate<Transform>(mapModel.tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90));
                newTile.name = string.Format("Tile: x({0}), y({1})", x, y);
                newTile.localScale = Vector3.one * (1 - mapModel.outlinePercent);
                newTile.parent = mapView.gameObject.transform;
            }
        }

        bool[,] obstacleMap = new bool[(int)mapModel.mapSize.x, (int)mapModel.mapSize.y];

        int obstacleCount = (int)(mapModel.mapSize.x * mapModel.mapSize.y * mapModel.obstaclePercent);
        for (int i = 0; i < obstacleCount; i++)
        {
            Coordinates randomCoordinate = GetRandomCoordinate();
            Vector3 obstaclePosition = CoordinatePosition(randomCoordinate.x, randomCoordinate.y);
            Transform newObstacle = GameObject.Instantiate<Transform>(mapModel.obstaclePrefab, obstaclePosition + Vector3.up * 0.5f, Quaternion.identity);
            newObstacle.name = string.Format("Obstacle : {0}", i);
            newObstacle.parent = mapView.gameObject.transform;
        }
    }

    private Vector3 CoordinatePosition(int x, int y)
    {
        return new Vector3(-mapModel.mapSize.x / 2 + 0.5f + x, 0, -mapModel.mapSize.y / 2 + 0.5f + y);
    }
    public Coordinates GetRandomCoordinate()
    {
        Coordinates randomCoordinates = shuffledTileCoords.Dequeue();
        shuffledTileCoords.Enqueue(randomCoordinates);
        return randomCoordinates;
    }
    public struct Coordinates
    {
        public int x;
        public int y;
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}