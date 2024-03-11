using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// enemy prefab , baseEnemy , countWave , timeWave , countEnemy , timeEnemy 
// Khoi tao so luong quai chay ban dau . Vi quai sau moi dot tang len nen phai dung bien khac . o day dung enemiesLeftToSpawn
// Neu thoi gian sinh quai da xay ra xong thi sinh spawner  . Phai co thoi gian chay luon ve 0 de khoi tao quai chay moi . Va khi cac gia 

// Su dung su kien de huy . dc dung khi huy obj o class khac va tao su kien o class nay 

public class EnemySpawner : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attribute")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f; // Quai sinh ra moi giay 
    [SerializeField] private float timeBetweenWaves = 5f; // Dot moi sinh ra quai
    [SerializeField] private float difficultyScallingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f/enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            // phai dat ve 0 kkhong thi ke thu sinh san vo han 
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--; 
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());

    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);

    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave,difficultyScallingFactor));
    }
}
