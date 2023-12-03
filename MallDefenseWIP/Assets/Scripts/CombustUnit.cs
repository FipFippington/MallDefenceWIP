using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustUnit : MonoBehaviour
{
    public float range;
    public GameObject currentTarget;
    bool aimLocked = false;
    public float zCheck;

    public float fireRate;
    float fireRateInit;
    public float damage;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
        fireRateInit = fireRate;
        currentTarget = GameObject.Find("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (currentTarget == null)
        {
            currentTarget = GameObject.Find("Tower");
        }
        else
        {
            if (fireRate <= 0 && currentTarget != null)
            {
                particles.Play();
                fireRate = fireRateInit;
            }
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentTarget = other.gameObject;
            other.gameObject.GetComponent<Enemy_AI>().Damaged(damage * Time.deltaTime, 0f);
        }
    }

    IEnumerator SingleFrameActivation()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForEndOfFrame();
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
