using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int maxHp = 20;
    public int currentHp = 20;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Debug.Log("GAME OVER");
            gameOver = true;
        }
    }

    public void Damage()
    {
        currentHp--;
        Debug.Log("hit" + (currentHp));
    }
}
