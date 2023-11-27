using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerAuto : MonoBehaviour
{    //Randomly picks enemy to spawn
    public GameObject[] enemyPrefabs;
    public int enemyIndex;
    //randomly picks place to spawn
    public int spawnIndex;
    //Time to spawn
    public float timeToSpawn = 6;
    public float timeToNextSpawn;

    private void Start()
    {
        //sets time
        timeToNextSpawn = Time.time + timeToSpawn;
    }

    // Start is called before the first frame update
    void Update()
    {
        //spawn condition
        if (timeToNextSpawn  <= Time.time)
        {
            //picking location
            int spawnIndex = Random.Range(1, 5);
            {
                //spawning
                if (spawnIndex == 1)
                {
                    Vector2 spawnPos = new Vector2(14, 7);
                    int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
                }
                if (spawnIndex == 2)
                {
                    Vector2 spawnPos = new Vector2(14, -7);
                    int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
                }
                if (spawnIndex == 3)
                {
                    Vector2 spawnPos = new Vector2(-14, 7);
                    int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
                }
                if (spawnIndex == 4)
                {
                    Vector2 spawnPos = new Vector2(-14, -7);
                    int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
                }
            }
            timeToNextSpawn = Time.time + timeToSpawn;
        }
    }
}
