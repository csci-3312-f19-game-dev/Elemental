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
            GlobalStats.health = 40;
            GlobalStats.elements = new int[] { 0, 0, 0, 0, 0 };
            GlobalStats.init = true;
            GlobalStats.perkPoints = 2;
            GlobalStats.exp = 0;
            GlobalStats.level = 1;
        }
    }

    public void checkLevelup()
    {
        if(GlobalStats.exp >= GlobalStats.level*5)
        {
            GlobalStats.exp = GlobalStats.exp - GlobalStats.level * 5;
            GlobalStats.level++;
            //this automatical levels up fire - remove
            //GlobalStats.elements[0] = GlobalStats.level;
            //
            GlobalStats.perkPoints++;
            Debug.Log("Level Up! "+GlobalStats.level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkLevelup();
        if (GlobalStats.justLoaded)
        {
            gameObject.transform.position = GlobalStats.playerPosition;
            GlobalStats.justLoaded = false;
        }
    }
}
