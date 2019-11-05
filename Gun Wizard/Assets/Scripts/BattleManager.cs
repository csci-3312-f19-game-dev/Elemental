using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject enemy;

    private Combatant playerScript;
    private Combatant enemyScript;

    private int enemyCurrentElement;
    private int playerCurrentElement;
    private int enemyCurrentAction; // attack->0, defent->1, reload->2, repair->3
    private int playerCurrentAction;


    void Start()
    {
        playerScript = player.GetComponent<Combatant>();
        enemyScript = enemy.GetComponent<Combatant>();
    }

    // Update is called once per frame

    public void setPlayerFire()
    {
        playerCurrentElement = 0;
    }
    public void setPlayerEarth()
    {
        playerCurrentElement = 1;
    }
    public void setPlayerMetal()
    {
        playerCurrentElement = 2;
    }
    public void setPlayerWater()
    {
        playerCurrentElement = 3;
    }
    public void setPlayerPlant()
    {
        playerCurrentElement = 4;
    }

    public void setPlayerAttack()
    {
        playerCurrentAction = 0;
    }
    public void setPlayerDefend()
    {
        playerCurrentAction = 1;
    }
    public void setPlayerReload()
    {
        playerCurrentAction = 2;
    }
    public void setPlayerRepair()
    {
        playerCurrentAction = 3;
    }

}
