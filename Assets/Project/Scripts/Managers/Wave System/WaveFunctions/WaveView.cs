using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int enemyCount;
}

public class WaveView : MonoBehaviour
{
    public Wavecontroller waveController { get; private set; } 
    public Wave[] waves;

    public void SetController(Wavecontroller waveController)
    {
        this.waveController = waveController;
    }
    private void Awake()
    {
        waveController = new Wavecontroller(this);
    }
    private void OnEnable()
    {
        waveController.OnEnable();
    }
    private void Start()
    {
        PlayerService.Instance.InitializePlayer();
        waveController.NextWave();
    }

    private void Update()
    {
        if (PlayerService.Instance.GetPlayerTransform() != null)
        {
            waveController.SpawnEnemies();
        }
    }

    private void OnDisable()
    {
        waveController.OnDisable();
    }
}