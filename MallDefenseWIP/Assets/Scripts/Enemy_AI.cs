using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed;
    public bool running;
    public float deceleration;
    private Rigidbody2D enemyRb;
    public GameObject tower;
    public TowerHealth towerHealth;
    //Time it takes until can get hit
    public float invincibleTime = 2;
    //Total time passed
    public float damageTime;
    public float damageDealt;
    public float maxHealth;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Tower");
        towerHealth = tower.GetComponent<TowerHealth>();
        enemyRb = GetComponent<Rigidbody2D>();
        damageTime = invincibleTime;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damageTime -= Time.deltaTime;
        if (running)
        {
            enemyRb.AddForce((tower.transform.position - transform.position).normalized * speed);
        }
        else
        {
            enemyRb.velocity = new Vector2(Mathf.Lerp(enemyRb.velocity.x, 0, deceleration), Mathf.Lerp(enemyRb.velocity.y, 0, deceleration));
            if (damageTime <= 0 && enemyRb.velocity.magnitude < 0.1f && !running)
            {
                towerHealth.Damage(damageDealt);
                damageTime = invincibleTime;
            }
        }
    }

    public void Damaged(float damageTaken)
    {
        Debug.Log("I'm being hit");
        currentHealth -= damageTaken;
        enemyRb.velocity = new Vector2((tower.transform.position - transform.position).normalized.x * enemyRb.velocity.x * -0.25f, (tower.transform.position - transform.position).normalized.y * enemyRb.velocity.y * -0.25f);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
