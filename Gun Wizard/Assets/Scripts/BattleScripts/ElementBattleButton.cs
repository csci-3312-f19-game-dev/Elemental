using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementBattleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow1;
    public GameObject arrow2;
    private Button battleButton;
    public int elementNum;
    void Start()
    {
        battleButton = GetComponent<Button>();
        battleButton.interactable = CheckLevel(elementNum);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        
    }

    // Update is called once per frame

    public void showArrows()
    {
        Debug.Log("Displaying Arrows.");
        arrow1.SetActive(true);
        arrow2.SetActive(true);
    }

    public void hideArrows()
    {
        Debug.Log("Hiding Arrows.");
        arrow1.SetActive(false);
        arrow2.SetActive(false);
    }

    public bool CheckLevel(int i)
    {
        if(GlobalStats.elements[i]<=0){
            return false;
        }
        else{
            return true;
        }
    }
}
