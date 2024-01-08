using UnityEngine;

public class MapView : MonoBehaviour
{
    public MapController mapController { get; private set; }
    public void SetMapController(MapController mapController)
    {
        this.mapController = mapController;
    }
}