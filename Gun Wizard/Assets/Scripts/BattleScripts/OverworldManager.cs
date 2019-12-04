using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject e in enemies)
        {
            Debug.Log("looking for id :" + e.GetComponent<Combatant>().id);
            if (GlobalStats.killedEnemies.Contains(e.GetComponent<Combatant>().id))
            {
                Debug.Log("desry");
                Destroy(e);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
