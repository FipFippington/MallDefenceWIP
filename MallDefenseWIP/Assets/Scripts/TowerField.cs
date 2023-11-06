using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        {
            other.gameObject.GetComponent<Enemy_AI>().running = false;
            Debug.Log("There's an object I'm slowing down");
        }
    }
}
