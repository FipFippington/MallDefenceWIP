using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUnitScript : MonoBehaviour
{
    public float maxLifetime = 10f;

    public float range;
    public GameObject currentTarget;
    bool aimLocked = false;
    public float zCheck;

    public float fireRate;
    public float fireRateInit;
    public float damage;
    public float pushback;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
        fireRateInit = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        maxLifetime -= Time.deltaTime;
        if (maxLifetime < 0 )
        {
            Destroy(gameObject);
        }

        fireRate -= Time.deltaTime;
        if (currentTarget == null)
        {
            aimLocked = false;
        }
        else
        {
            float zRotation = Mathf.Atan((currentTarget.transform.position.y - transform.position.y)/((currentTarget.transform.position.x - transform.position.x)))*180/Mathf.PI + 90f;
            zCheck = zRotation;
            aimLocked = true;
            if ((currentTarget.transform.position.x - transform.position.x) > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, zRotation);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, zRotation + 180);
            }

            if (fireRate <= 0 && currentTarget != null)
            {
                currentTarget.GetComponent<Enemy_AI>().Damaged(damage, pushback);
                particles.Play();
                fireRate = fireRateInit;
            }
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (!aimLocked && other.gameObject.CompareTag("Enemy"))
        {
            currentTarget = other.gameObject;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject == currentTarget)
        {
            currentTarget = null;
        }
    }
}
