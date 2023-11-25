using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed;
    public bool running;
    public float deceleration;
    private Rigidbody2D enemyRb;
    public GameObject Tower;
    public TowerHealth TowerHealth;
    //Time it takes until can get hit
    public float invincibleTime = 2;
    //Total time passed
    public float damageTime;

    // Start is called before the first frame update
    void Start()
    {
        TowerHealth = Tower.GetComponent<TowerHealth>();
        enemyRb = GetComponent<Rigidbody2D>();
        damageTime = Time.time + invincibleTime;
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
            enemyRb.velocity = new Vector3(Mathf.Lerp(enemyRb.velocity.x, 0, deceleration), Mathf.Lerp(enemyRb.velocity.y, 0, deceleration));
            if (damageTime <= Time.time)
            {
                TowerHealth.Damage();
                damageTime = invincibleTime + Time.time;
            }
        }
    }
}
