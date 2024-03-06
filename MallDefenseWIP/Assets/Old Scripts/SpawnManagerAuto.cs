using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerAuto : MonoBehaviour
{    //Randomly picks enemy to spawn
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
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
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (i != spawnIndex)
                    {
                        Debug.Log("not this point.");
                    }
                    else
                    {
                        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, enemyPrefabs[enemyIndex].transform.rotation);
                    }
                }
            }
            timeToNextSpawn = Time.time + timeToSpawn;
        }
    }
}
