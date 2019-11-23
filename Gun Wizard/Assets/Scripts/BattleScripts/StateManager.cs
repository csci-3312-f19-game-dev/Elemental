using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject elementMenue;
    public GameObject actionMenue;
    public GameObject bm;
    public GameObject enemy;
    public GameObject playerAttackAnimator;
    public GameObject enemyAttackAnimator;
    public GameObject player;
    private Animator enemyBodyAnim;
    private Animator playerBodyAnim;
    private Animator enemyAttackAnim;
    private Animator playerAttackAnim;
    private Button attackButton;
    private Button defendButton;
    
    void Awake()
    {
        elementMenue.SetActive(true);
        Debug.Log("here");
        actionMenue.SetActive(false);
        attackButton = actionMenue.transform.Find("Attack").GetComponent<Button>();
        defendButton = actionMenue.transform.Find("Block").GetComponent<Button>();
        enemyAttackAnim = enemyAttackAnimator.GetComponent<Animator>();
        playerAttackAnim = playerAttackAnimator.GetComponent<Animator>();
        enemyBodyAnim = enemy.GetComponent<Animator>();
        playerBodyAnim = player.GetComponent<Animator>();

    }

    // Update is called once per frame

    public void pickedElement()
    {
        elementMenue.SetActive(false);
        actionMenue.SetActive(true);
        if(bm.GetComponent<BattleManager>().getPlayerAmmo()>0){
            attackButton.interactable = true;
        }
        else{
            attackButton.interactable = false;
        }
        if(bm.GetComponent<BattleManager>().getPlayerShields()>0)
        {
            defendButton.interactable = true;
        }
        else
        {
            defendButton.interactable = false;
        }
    }

    public void pickedAction()
    {
        elementMenue.SetActive(false);
        actionMenue.SetActive(false);
        bm.GetComponent<BattleManager>().getOutcome();
    }

    public void GoBack()
    {
        actionMenue.SetActive(false);
        elementMenue.SetActive(true);
    }

    public void animate(int playerElem, int playerAct, int enemyElem, int enemyAct)
    {
        if (playerAct == 0) playerBodyAnim.SetTrigger("Attack");
        if (playerAct == 1) playerBodyAnim.SetTrigger("Reload");
        if (playerAct == 2) playerBodyAnim.SetTrigger("Block");
        if (playerAct == 3) playerBodyAnim.SetTrigger("Repair");

        if (enemyAct == 0) enemyBodyAnim.SetTrigger("Attack");
        if (enemyAct == 1) enemyBodyAnim.SetTrigger("Reload");
        if (enemyAct == 2) enemyBodyAnim.SetTrigger("Block");
        if (enemyAct == 3) enemyBodyAnim.SetTrigger("Repair");

        if (playerAct == 0)
        {
            if (playerElem == 0) enemyAttackAnim.SetTrigger("FA");
            if (playerElem == 1) enemyAttackAnim.SetTrigger("EA");
            if (playerElem == 2) enemyAttackAnim.SetTrigger("MA");
            if (playerElem == 3) enemyAttackAnim.SetTrigger("WA");
            if (playerElem == 4) enemyAttackAnim.SetTrigger("PA");
        }
        if (enemyAct == 0)
        {
            if (enemyElem == 0) playerAttackAnim.SetTrigger("FA");
            if (enemyElem == 1) playerAttackAnim.SetTrigger("EA");
            if (enemyElem == 2) playerAttackAnim.SetTrigger("MA");
            if (enemyElem == 3) playerAttackAnim.SetTrigger("WA");
            if (enemyElem == 4) playerAttackAnim.SetTrigger("PA");
        }


        elementMenue.SetActive(true);
    }

    public void returnToOverworld()
    {
        GlobalStats.justLoaded = true;
        SceneManager.LoadScene(sceneBuildIndex: GlobalStats.lastScene);
    }

    void Update()
    {
        
    }
}
