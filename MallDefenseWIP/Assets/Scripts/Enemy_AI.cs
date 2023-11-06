using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed;
    public bool running;
    private Rigidbody2D enemyRb;
    public GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            enemyRb.AddForce((Tower.transform.position - transform.position).normalized * speed);
        }
        else
        {
            enemyRb.velocity = new Vector3(Mathf.Lerp(enemyRb.velocity.x, 0, 0.5f), Mathf.Lerp(enemyRb.velocity.y, 0, 0.5f));
            Debug.Log("Trying to stop now");
        }
    }
}
