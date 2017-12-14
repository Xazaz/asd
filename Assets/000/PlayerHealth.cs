using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int curHealth = 100;
    public Text hpText;



    void Start()
    {
    }


    void Update()
    {
        AddjustCurrentHealth(0);
        hpText.text = "Player HP:" + curHealth;


    }


    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

    }
}