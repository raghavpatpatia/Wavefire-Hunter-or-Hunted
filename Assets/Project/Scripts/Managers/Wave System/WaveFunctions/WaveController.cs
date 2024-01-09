using System.Collections;
using UnityEngine;

public class Wavecontroller
{
    public WaveView waveView { get; private set; }
    private Wave currentWave;
    private int currentWaveNumber;
    private int enemiesRemainingToSpawn;
    private int enemiesRemainingAlive;
    public Wavecontroller(WaveView waveView)
    {
        this.waveView = waveView;
        waveView.SetController(this);
    }
    public void SpawnEnemies()
    {
        if (enemiesRemainingToSpawn > 0)
        {
            EnemyService.Instance.GetEnemy(GameSceneManager.Instance.enemyScriptableObject);
            enemiesRemainingToSpawn -= 1;
        }
    }

    private void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        if (currentWaveNumber >= waveView.waves.Length)
        {
            EventManager.Instance.InvokeGameOverText("Player Won!!");
            EventManager.Instance.InvokeActivateGameOverPanel();
        }
        currentWaveNumber++;
        EventManager.Instance.InvokeSetWave(currentWaveNumber);
        if (currentWaveNumber - 1 < waveView.waves.Length)
        {
            currentWave = waveView.waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    public void Reset()
    {
        PlayerService.Instance.ResetPlayer();
        ReturnAllEnemies();
        currentWaveNumber = 0;
        NextWave();
    }

    public void ReturnAllEnemies()
    {
        EnemyService.Instance.ReturnAllEnemies();
    }

    public void OnEnable() 
    { 
        EventManager.Instance.OnEnemyDeath += OnEnemyDeath;
        EventManager.Instance.OnReset += Reset;
    }
    public void OnDisable() 
    { 
        EventManager.Instance.OnEnemyDeath -= OnEnemyDeath;
        EventManager.Instance.OnReset -= Reset;
    }
}