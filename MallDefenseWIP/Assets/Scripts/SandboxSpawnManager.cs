using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxSpawnManager : MonoBehaviour
{
    public GameObject pointing;
    public RectTransform canvasForPlacing;
    public GameObject[] spawnPoints;
    public bool readyToPickSpawn;
    float xPosMulti;
    float yPosMulti;
    // Start is called before the first frame update
    void Start()
    {
        xPosMulti = canvasForPlacing.sizeDelta.x / 2;
        yPosMulti = canvasForPlacing.sizeDelta.y / 2;
        Debug.Log(xPosMulti);
        Debug.Log(yPosMulti);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToPickSpawn)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Vector2 normalizedDif = (spawnPoints[i].transform.position - transform.position).normalized;
                Instantiate<GameObject>(pointing.gameObject, new Vector3(normalizedDif.x, normalizedDif.y, 1) * 5f, Quaternion.identity);
                if (i == spawnPoints.Length)
                {
                    readyToPickSpawn = false;
                }
            }
        }
    }
}
