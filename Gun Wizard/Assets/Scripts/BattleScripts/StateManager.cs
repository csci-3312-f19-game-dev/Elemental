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
    private Button attackButton;
    private Button defendButton;
    void Awake()
    {
        elementMenue.SetActive(true);
        Debug.Log("here");
        actionMenue.SetActive(false);
        attackButton = actionMenue.transform.Find("Attack").GetComponent<Button>();
        defendButton = actionMenue.transform.Find("Block").GetComponent<Button>();
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
