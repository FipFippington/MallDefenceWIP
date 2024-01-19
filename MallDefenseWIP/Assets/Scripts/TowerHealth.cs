using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public float maxHp = 20;
    public float currentHp;
    public bool gameOver = false;
    public Slider lol;
    public Image fill;
    // Start is called before the first frame update

    void Start()
    {
        lol.maxValue = maxHp;
        lol.value = 0;
        lol.fillRect.gameObject.SetActive(false);
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            GameObject.Find("Management").GetComponent<GameManager>().Over();
        }
        UpdateValue(currentHp);
    }

    public void Damage(float damageTaken)
    {
        currentHp = currentHp - damageTaken;
    }

    public void UpdateValue(float currentHealth)
    {
        lol.fillRect.gameObject.SetActive(true);
        lol.value = Mathf.Lerp(lol.value, currentHealth, 0.025f);
    }
}
