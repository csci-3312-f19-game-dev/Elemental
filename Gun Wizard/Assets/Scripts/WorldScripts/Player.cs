using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Combatant playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponent<Combatant>();
        if (GlobalStats.init == false)
        {
            GlobalStats.maxHealth = 50;
            GlobalStats.health = GlobalStats.maxHealth;
            GlobalStats.elements = new int[] { 0, 0, 0, 0, 0 };
            GlobalStats.init = true;
            GlobalStats.perkPoints = -1;
            GlobalStats.exp = 15;
// Debug.Log("Setting Level.");
            GlobalStats.level = 1;
            GlobalStats.init = true;

        }
    }

    public void checkLevelup()
    {
        if(GlobalStats.exp >= GlobalStats.level*5)
        {

            GlobalStats.perkPoints+= (int)(GlobalStats.exp)/ (int)(GlobalStats.level * 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalStats.justLoaded)
        {
            checkLevelup();
            gameObject.transform.position = GlobalStats.playerPosition;
            GlobalStats.justLoaded = false;
        }
    }
}
