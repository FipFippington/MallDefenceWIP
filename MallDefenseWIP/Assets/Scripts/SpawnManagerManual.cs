using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerManual : MonoBehaviour
{
    //Randomly picks enemy to spawn
    public GameObject[] enemyPrefabs;
    public int enemyIndex;
    //randomly picks place to spawn
    public int spawnIndex;
    // Start is called before the first frame update
    void Update()
    {
        //spawn condition
        if (Input.GetKeyDown(KeyCode.S))
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
        }
    }
}
