using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyAI : MonoBehaviour
{
    public float speed;
    public bool running;
    public float deceleration;
    public NodeList pathing;
    public int nodeToTravelTo = 0;

    Rigidbody2D enemyRb;

    public float damageTime;
    public float invincibleTime = 2f;
    public float damageDealt;

    public GameObject tower;
    public TowerHealth towerHealth;
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Elevator");
        towerHealth = tower.GetComponent<TowerHealth>();
        damageTime = invincibleTime;
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        damageTime -= Time.deltaTime;
        if (running)
        {
            transform.Translate((pathing.turningPoints[nodeToTravelTo].transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
        else if (!running && nodeToTravelTo == pathing.turningPoints.Length - 1)
        {
            enemyRb.velocity = new Vector2(Mathf.Lerp(enemyRb.velocity.x, 0, deceleration), Mathf.Lerp(enemyRb.velocity.y, 0, deceleration));
            if (damageTime <= 0 && enemyRb.velocity.magnitude < 0.1f && !running)
            {
                towerHealth.Damage(damageDealt);
                damageTime = invincibleTime;
            }
        }

        if ((pathing.turningPoints[nodeToTravelTo].transform.position - transform.position).magnitude < 0.1f)
        {
            nodeToTravelTo++;
        }
    }
}