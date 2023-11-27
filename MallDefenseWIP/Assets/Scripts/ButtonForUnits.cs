using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForUnits : MonoBehaviour
{
    public Button press;
    public GameObject unitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        press = GetComponent<Button>();
        press.onClick.AddListener(setReady);
    }

    void setReady()
    {
        GameObject manager = GameObject.Find("Management");
        manager.GetComponent<GameManager>().spawnPrefab = unitPrefab;
        manager.GetComponent<GameManager>().readyToPlace = true;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttons)
        {
            button.GetComponent<ButtonForUnits>().press.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
