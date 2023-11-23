using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool readyToPlace = false;
    public GameObject spawnPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToPlace)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, -Vector3.forward);
                if (hit)
                {
                    if (!hit.collider.gameObject.CompareTag("Ground"))
                    {
                        Debug.Log("That's not ground!");
                    }
                    else if (hit.collider.gameObject.CompareTag("Ground"))
                    {
                        Instantiate(spawnPrefab, hit.point, Quaternion.identity);
                        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
                        foreach (GameObject button in buttons)
                        {
                            button.GetComponent<Button>().interactable = true;
                        }
                        readyToPlace = false;
                    }
                }
            }
        }
    }
}
