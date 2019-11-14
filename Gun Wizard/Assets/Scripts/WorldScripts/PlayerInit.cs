using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public Combatant playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponent<Combatant>();
        if (GlobalStats.init == false)
        {
            GlobalStats.health = 20;
            GlobalStats.elements = new int[] { 1, 1, 1, 1, 1 };
            GlobalStats.init = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
