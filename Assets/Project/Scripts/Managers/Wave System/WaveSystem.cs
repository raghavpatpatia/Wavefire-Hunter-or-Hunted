using UnityEngine;

[System.Serializable]
public class Wave
{
    public int enemyCount;
    //public float timeBetweenSpawns;
}
public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;
    public int currentWaveNumber;

    private int enemiesRemainingToSpawn;
    private int enemiesRemainingAlive;
    //private float nextSpawnTime;
    private void OnEnable()
    {
        EventManager.Instance.OnEnemyDeath += OnEnemyDeath;
    }

    private void Start()
    {
        NextWave();
    }

    //private void Update()
    //{
    //    if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
    //    {
    //        enemiesRemainingToSpawn--;
    //        nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
    //        EnemyService.Instance.GetEnemy(GameSceneManager.Instance.enemyScriptableObject);
    //    }
    //}

    private void Update()
    {
        if (PlayerService.Instance.GetPlayerTransform() != null)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        while (enemiesRemainingToSpawn > 0)
        {
            EnemyService.Instance.GetEnemy(GameSceneManager.Instance.enemyScriptableObject);
            enemiesRemainingToSpawn--;
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

    private void NextWave()
    {
        currentWaveNumber++;
        Debug.Log(currentWaveNumber);
        if(currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber-1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeath -= OnEnemyDeath;
    }
}