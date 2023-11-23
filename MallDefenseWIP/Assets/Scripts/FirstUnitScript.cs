using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUnitScript : MonoBehaviour
{
    public float range;
    public GameObject currentTarget;
    bool aimLocked = false;
    public float zCheck;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            aimLocked = false;
        }
        else
        {
            float zRotation = Mathf.Atan((currentTarget.transform.position.y - transform.position.y)/((currentTarget.transform.position.x - transform.position.x)))*180/Mathf.PI;
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
