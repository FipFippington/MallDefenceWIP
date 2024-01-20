using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustUnit : MonoBehaviour
{
    public float maxLifetime = 15f;

    public float range;
    public GameObject currentTarget;
    bool aimLocked = false;
    public float zCheck;

    public float maxTime;
    float maxTimeInit;
    public float cooldown;
    public float damage;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
        maxTimeInit = maxTime;
        currentTarget = GameObject.Find("Tower");
        StartCoroutine(QuickSpin());
    }

    // Update is called once per frame
    void Update()
    {
        maxTime -= Time.deltaTime;
        if (maxTime >= 0)
        {
            particles.Play();
        }

        if (maxTime < 0 && maxTime > -cooldown)
        {
            particles.Stop();
            GetComponent<CircleCollider2D>().enabled = false;
        }

        if (maxTime <= -cooldown)
        {
            maxTime = maxTimeInit;
            GetComponent<CircleCollider2D>().enabled = true;
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

    IEnumerator QuickSpin()
    {
        yield return new WaitForEndOfFrame();
        transform.rotation = Quaternion.Euler(Vector3.right * 180);
        yield return new WaitForEndOfFrame();
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
