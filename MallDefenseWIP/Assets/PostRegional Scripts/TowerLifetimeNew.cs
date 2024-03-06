using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLifetimeNew : MonoBehaviour
{
    public float maxLifetime = 15f;
    public float maxLifetimeInit;

    // Start is called before the first frame update
    void Start()
    {
        maxLifetimeInit = maxLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        maxLifetime -= Time.deltaTime;
        if (maxLifetime < 0 )
        {
            Destroy(gameObject);
        }
    }

    void InitializeLife(float lifetime)
    {
        maxLifetime = lifetime;
    }
}
