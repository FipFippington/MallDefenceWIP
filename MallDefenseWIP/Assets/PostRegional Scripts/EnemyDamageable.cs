using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth;
    Rigidbody2D enemyRb;
    NewEnemyAI enemyAI;
    public int manaGranted;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<NewEnemyAI>();
        enemyRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(float damageTaken, float pushPower)
    {
        Debug.Log("I'm being hit");
        currentHealth -= damageTaken;
        Vector2 currentVelocity = enemyRb.velocity;
        enemyRb.velocity = enemyRb.velocity + new Vector2((enemyAI.pathing.turningPoints[enemyAI.nodeToTravelTo].transform.position - transform.position).normalized.x * enemyRb.velocity.magnitude * -0.25f * pushPower, (enemyAI.pathing.turningPoints[enemyAI.nodeToTravelTo].transform.position - transform.position).normalized.y * enemyRb.velocity.magnitude * -0.25f * pushPower);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Management").GetComponent<GameManager>().manaCount += manaGranted;
        }
        if (currentVelocity.magnitude < enemyRb.velocity.magnitude)
        {
            Debug.Log("I got pushed back!");
        }

        StartCoroutine(GetPushedLol(pushPower));
    }

    IEnumerator GetPushedLol(float power)
    {
        enemyAI.running = false;
        yield return new WaitForSeconds(power/12f);
        enemyAI.running = true;
    }
}
