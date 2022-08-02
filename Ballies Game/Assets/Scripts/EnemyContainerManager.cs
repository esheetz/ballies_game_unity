using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerManager : MonoBehaviour
{
    public EnemyManager enemyPrefab;
    public float spawnFrequencySeconds = 2.0f;
    private float timer = 0.0f;
    public float spawnRadius;
    public int numColors = 4;
    private int enemyCounter = 0;
    private int enemyColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        // set the starting color
        enemyColor = Random.Range(0, numColors);
        // set the spawn radius
        spawnRadius = 50.0f;//Mathf.Max(Screen.width / 2, Screen.height / 2);
        Debug.Log("Radius=" + spawnRadius); // TODO?
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        SpawnEnemy();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    private void ResetTimer()
    {
        timer -= spawnFrequencySeconds;
    }

    private bool CheckSpawnEnemy()
    {
        return (timer > spawnFrequencySeconds);
    }

    private void SpawnEnemy()
    {
        if (CheckSpawnEnemy())
        {
            enemyCounter += 1;
            float enemyX = 0.0f;// Random.Range(0.0f, spawnRadius);
            float enemyY = 0.0f;// Random.Range(0.0f, spawnRadius);
            Vector2 enemyPos = new Vector2(enemyX, enemyY);
            // TODO fix spawning positions
            EnemyManager newEnemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity, this.gameObject.transform);
            newEnemy.gameObject.name = "Enemy" + enemyCounter;
            newEnemy.SetColor(enemyColor);
            enemyColor = (enemyColor + 1) % numColors;
            ResetTimer();
        }
    }
}
