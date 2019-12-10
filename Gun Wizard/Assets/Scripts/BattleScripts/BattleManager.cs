using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject enemy;
    public GameObject stateManager;
    public GameObject enemyAnimator;
    public AudioClip gunFiring;
    public AudioSource playerSource;
    public AudioSource enemySource;
    public AudioClip reloading;
    private Combatant playerScript;
    private Combatant enemyScript;
    private Enemy enemyMethods;
    private StateManager sm;
    private Animator enemyAnim;

    private int enemyCurrentElement;
    private int playerCurrentElement;
    private int enemyCurrentAction; // attack->0, defent->1, reload->2, repair->3
    private int playerCurrentAction;
    //public AudioSource playerAudioSource;
    private AudioClip playerActionAudio;
    private AudioClip enemyActionAudio;

    //public SimpleHealthBar playerHealthBar;
    //public SimpleHealthBar enemyHealthBar;

    void Start()
    {
        playerScript = player.GetComponent<Combatant>();
        enemyScript = enemy.GetComponent<Combatant>();
        enemyMethods = enemy.GetComponent<Enemy>();
        sm = stateManager.GetComponent<StateManager>();
        playerScript.health = GlobalStats.health;
        playerScript.elementLevels = GlobalStats.elements;
        playerScript.ammo = 1;
        playerScript.shields = 1;

    }

    // Update is called once per frame

    public void setPlayerFire()
    {
        playerCurrentElement = 0;
        player.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void setPlayerEarth()
    {
        playerCurrentElement = 1;
        player.GetComponent<SpriteRenderer>().color = new Color(0.8f, .6f, .1f,1);

    }
    public void setPlayerMetal()
    {
        playerCurrentElement = 2;
        player.GetComponent<SpriteRenderer>().color = Color.gray;

    }
    public void setPlayerWater()
    {
        playerCurrentElement = 3;
        player.GetComponent<SpriteRenderer>().color = Color.blue;

    }
    public void setPlayerPlant()
    {
        playerCurrentElement = 4;
        player.GetComponent<SpriteRenderer>().color = Color.green;

    }

    public void setPlayerAttack()
    {
        playerCurrentAction = 0;
        playerActionAudio = gunFiring;
    }
    public void setPlayerDefend()
    {
        playerCurrentAction = 1;
    }
    public void setPlayerReload()
    {
        playerCurrentAction = 2;
        playerActionAudio = reloading;
    }
    public void setPlayerRepair()
    {
        playerCurrentAction = 3;
    }

    public int getPlayerAmmo()
    {
        Debug.Log("Ammo: " + playerScript.ammo);
        return playerScript.ammo; 
    }

    public int getPlayerShields()
    {
        return playerScript.shields;
    }

    public void getOutcome()
    {
        int tempEDmgTaken = 0;
        int tempPDmgTaken = 0;
        enemyCurrentElement = enemyMethods.getElement();
        enemyCurrentAction = enemyMethods.getAction();
        if (enemyCurrentElement == 0) enemy.GetComponent<SpriteRenderer>().color = Color.red;
        if (enemyCurrentElement == 1) enemy.GetComponent<SpriteRenderer>().color = new Color(0.8f, .6f, .1f,1); ;
        if (enemyCurrentElement == 2) enemy.GetComponent<SpriteRenderer>().color = Color.gray;
        if (enemyCurrentElement == 3) enemy.GetComponent<SpriteRenderer>().color = Color.blue;
        if (enemyCurrentElement == 4) enemy.GetComponent<SpriteRenderer>().color = Color.green;

        if (playerCurrentAction == 0) {
            tempEDmgTaken = playerScript.elementLevels[playerCurrentElement] * multiplier(playerCurrentElement, enemyCurrentElement);
            playerScript.ammo -= 1;
        }
        if (enemyCurrentAction == 0)
        {
            tempPDmgTaken = enemyScript.elementLevels[enemyCurrentElement] * multiplier(enemyCurrentElement, playerCurrentElement);
            enemyScript.ammo -= 1;
            enemyActionAudio = gunFiring;
        }
        if (playerCurrentAction == 1) {
            tempPDmgTaken -= playerScript.elementLevels[playerCurrentElement] * multiplier(playerCurrentElement, enemyCurrentElement);
            if (tempPDmgTaken < 0) {
                tempPDmgTaken = 0;
            }
            playerScript.shields -= 1;
        }
        if (enemyCurrentAction == 1)
        {
            tempEDmgTaken -= enemyScript.elementLevels[enemyCurrentElement] * multiplier(enemyCurrentElement, playerCurrentElement);
            if (tempEDmgTaken < 0)
            {
                tempEDmgTaken = 0;
            }
            enemyScript.shields -= 1;
        }
        if (playerCurrentAction == 2) {
            playerScript.ammo += 1;
        }
        if (enemyCurrentAction == 2) {
            enemyActionAudio = reloading;
            enemyScript.ammo += 1;
        }
        if (playerCurrentAction == 3)
        {
            playerScript.shields += 1;
        }
        if (enemyCurrentAction == 3)
        {
            enemyScript.shields += 1;
        }
        playerSource.PlayOneShot(playerActionAudio, 0.7F);
        enemySource.PlayOneShot(enemyActionAudio, 0.7F);
        sm.animate(playerCurrentElement, playerCurrentAction, tempPDmgTaken,enemyCurrentElement, enemyCurrentAction, tempEDmgTaken);

        playerScript.health -= tempPDmgTaken;
        enemyScript.health -= tempEDmgTaken;
        //playerHealthBar.UpdateBar(playerScript.health, 20);
        //enemyHealthBar.UpdateBar(enemyScript.health, GlobalStats.enemy.health);

        if(enemyScript.health < 1)
        {
            GlobalStats.health = playerScript.health;
            GlobalStats.exp += enemyScript.exp;
            GlobalStats.score += enemyScript.id;
            ArrayList prevKilled = new ArrayList { };
            foreach(int e in GlobalStats.killedEnemies)
            {
                prevKilled.Add(e);
            }
            prevKilled.Add(enemyScript.id);
            //Debug.Log("this should not be 0 :" +enemyScript.id);
            GlobalStats.killedEnemies = prevKilled;
            //Debug.Log("was killed id :" + GlobalStats.killedEnemies[0]);

            if(enemyScript.id != 5)
            {
                sm.returnToOverworld();
            }
            else
            {
                sm.playerWin(playerScript.health);
            }
        }
        if(playerScript.health < 1)
        {
            sm.playerDeath();
        }
    }

    //returns what to multiply e1 by
    private int multiplier(int e1, int e2) {
        if (elementCompare(e1, e2) == 1) return 2;
        else return 1;
    }

    //returns -1 if e2 beats e1, 0 if they're the same, and 1 if e1 beats e2
    private int elementCompare(int e1, int e2) {
        if (e1 == e2) return 0;
        if ((((e1 + 2) % 5) == e2) || (((e1 + 4) % 5) == e2)) return 1;
        else return -1;
    }
}
