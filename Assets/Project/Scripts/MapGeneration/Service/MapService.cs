using UnityEngine;
public class MapService : Singleton<MapService>
{
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private MapView MapView;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        MapController map = new MapController(mapScriptableObject, MapView);
    }
}