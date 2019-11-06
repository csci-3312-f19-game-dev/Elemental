using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject elementMenue;
    public GameObject actionMenue;
    public GameObject bm;
    public GameObject enemy;

    void Start()
    {
        elementMenue.SetActive(true);
        actionMenue.SetActive(false);
    }

    // Update is called once per frame

    public void pickedElement()
    {
        elementMenue.SetActive(false);
        actionMenue.SetActive(true);
    }

    public void pickedAction()
    {
        elementMenue.SetActive(false);
        actionMenue.SetActive(false);
        bm.GetComponent<BattleManager>().getOutcome();
    }

    public void animate(int playerElem, int playerAct, int enemyElem, int enemyAct)
    {
        elementMenue.SetActive(true);
    }


    void Update()
    {
        
    }
}
