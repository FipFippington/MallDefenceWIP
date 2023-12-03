using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool readyToPlace = false;
    public GameObject spawnPrefab;
    public GameObject gameOverText;
    public GameObject unitDisplay;
    public GameObject unitButtonSet;
    public GameObject unitSummoner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToPlace)
        {
            unitDisplay.SetActive(false);
            unitButtonSet.SetActive(false);
            unitSummoner.SetActive(true);
            unitSummoner.GetComponent<Button>().interactable = false;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, -Vector3.forward);
                if (hit)
                {
                    if (!hit.collider.gameObject.CompareTag("Ground") && !hit.collider.gameObject.CompareTag("Unit Range") || hit.collider.gameObject.CompareTag("Tower"))
                    {
                        Debug.Log("That's not ground!");
                    }
                    else if (hit.collider.gameObject.CompareTag("Ground") || hit.collider.gameObject.CompareTag("Unit Range"))
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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, -Vector3.forward);
                if (hit)
                {
                    if (!hit.collider.gameObject.CompareTag("Unit"))
                    {
                        unitDisplay.SetActive(false);
                    }
                    else
                    {
                        unitDisplay.SetActive(true);
                    }
                }
            }
        }
    }

    public void Over()
    {
        gameOverText.SetActive(true);
    }
}
