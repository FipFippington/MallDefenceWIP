using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByWaves : MonoBehaviour
{
    GameObject[] spawnPoints;

    public List<Wave> wavesToSpawn;

    int waveToSpawn = 0;
    int enemyToSpawnFromWave = 0;
    float temporarySpawnTimer = 3.5f;
    float timeBetweenWaves = 7f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");
    }

    // Update is called once per frame
    void Update()
    {
        temporarySpawnTimer -= Time.deltaTime;

        // Checks if it is correct time to spawn enemy
        if (temporarySpawnTimer <= 0)
        {
            // Checks if all enemies are cleared from this wave. then transitions to next wave
            if (enemyToSpawnFromWave >= wavesToSpawn[waveToSpawn].enemiesToSpawn.Length && GameObject.FindWithTag("Enemy") == null)
            {
                waveToSpawn++;
                enemyToSpawnFromWave = 0;
                temporarySpawnTimer = timeBetweenWaves;
            }
            // Checks if there are still enemies on the field without any more to spawn
            else if (enemyToSpawnFromWave >= wavesToSpawn[waveToSpawn].enemiesToSpawn.Length && GameObject.FindWithTag("Enemy") != null)
            {
                temporarySpawnTimer = 0.1f;
            }
            // If the other two are false, then spawn a new enemy from current wave
            else
            {
                int spawnPointChosen = Random.Range(0, spawnPoints.Length);
                GameObject instantiatedEnemy = Instantiate(wavesToSpawn[waveToSpawn].enemiesToSpawn[enemyToSpawnFromWave], spawnPoints[spawnPointChosen].transform.position, Quaternion.identity);
                instantiatedEnemy.GetComponent<NewEnemyAI>().pathing = spawnPoints[spawnPointChosen].GetComponent<PublicNodeList>().nodesToFollowForThisPoint;
                enemyToSpawnFromWave++;
                temporarySpawnTimer = 3.5f;
            }
        }
    }
}
