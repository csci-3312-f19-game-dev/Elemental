﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject playerHealth;
    public GameObject playerAmmo;
    public GameObject playerShields;
    //public GameObject enemyHealth;
    public GameObject enemyAmmo;
    public GameObject enemyShields;

    public GameObject player;
    public GameObject enemy;

    private Combatant playerScript;
    private Combatant enemyScript;

    public SimpleHealthBar playerHealthBar;
    public SimpleHealthBar enemyHealthBar;

    void Start()
    {
        playerScript = player.GetComponent<Combatant>();
        enemyScript = enemy.GetComponent<Combatant>();
    }

    // Update is called once per frame
    void Update()
    {

        //playerHealth.GetComponent<Text>().text = "x"+playerScript.health;
        //enemyHealth.GetComponent<Text>().text = "x" + enemyScript.health;
        playerAmmo.GetComponent<Text>().text = "x" + playerScript.ammo;
        enemyAmmo.GetComponent<Text>().text = "x" + enemyScript.ammo;
        playerShields.GetComponent<Text>().text = "x" + playerScript.shields;
        enemyShields.GetComponent<Text>().text = "x" + enemyScript.shields;
        playerHealthBar.UpdateBar(playerScript.health, GlobalStats.maxHealth);
        enemyHealthBar.UpdateBar(enemyScript.health, GlobalStats.enemy.health);


    }
}
