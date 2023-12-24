using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool readyToPlace = false;
    public GameObject spawnPrefab;
    public GameObject gameOverText;
    public GameObject unitDisplay;
    public TMP_Text unitStats;
    public TMP_Text unitName;
    public GameObject unitButtonSet;
    public GameObject unitSummoner;
    public TMP_Text manaText;
    public int manaCount = 2;
    public int manaToTake;
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
                    if (hit.collider.gameObject.CompareTag("Ground") || hit.collider.gameObject.CompareTag("Unit Range"))
                    {
                        Debug.Log(hit.point);
                        Debug.Log(hit.collider.gameObject);
                        Instantiate(spawnPrefab, new Vector3 (hit.point.x, hit.point.y, 0), Quaternion.identity);
                        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
                        foreach (GameObject button in buttons)
                        {
                            button.GetComponent<Button>().interactable = true;
                        }
                        manaCount -= manaToTake;
                        readyToPlace = false;
                    }
                    else
                    {
                        Debug.Log("That's not ground!");
                        Debug.Log(hit.point);
                        Debug.Log(hit.collider.gameObject);
                    }
                    Debug.DrawLine(transform.position, ray, Color.white, Time.deltaTime);
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
                        if (hit.collider.gameObject.transform.parent.GetComponent<CombustUnit>() != null)
                        {
                            CombustUnit combustible = hit.collider.gameObject.transform.parent.GetComponent<CombustUnit>();
                            unitStats.text = "Damage: " + combustible.damage + "/s" + "\nFire Rate: N/A" + "\nTargeting: None";
                            unitName.text = hit.collider.gameObject.name;
                        }
                        else
                        {
                            FirstUnitScript unitScript = hit.collider.gameObject.transform.parent.GetComponent<FirstUnitScript>();
                            unitName.text = hit.collider.gameObject.name;
                            unitStats.text = "Damage: " + unitScript.damage + "\nFire Rate: " + (Mathf.Round((1/unitScript.fireRateInit)*100)/100) + "/s" + "\nTargeting: Single";
                        }
                    }
                }
            }
        }

        manaText.text = manaCount.ToString();
    }

    public void Over()
    {
        gameOverText.SetActive(true);
    }
}
