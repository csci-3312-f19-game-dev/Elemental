using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenueManager : MonoBehaviour
{
    public GameObject elementMenue;
    public SimpleHealthBar healthBar;
    private bool inventoryOpen;
    // Start is called before the first frame update
    void Start()
    {
        elementMenue.SetActive(false);
        inventoryOpen = false;
    }

    public void inventoryButton()
    {
        if (!inventoryOpen)
        {
            openInventory();
        }
        else
        {
            closeInventory();
        }
    }

    private void openInventory()
    {
        elementMenue.SetActive(true);
        inventoryOpen = true;
        if(GlobalStats.perkPoints<=0){
            deactivateButtons();
        }
        else {
            activateButtons();
        }

    }

    private void deactivateButtons()
    {
        Debug.Log("Deactivating Level Up buttons");
        for (int i = 0; i < 5; i++)
        {
            elementMenue.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void activateButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            elementMenue.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
    }


    public void levelUp(int elem)
    {
        GlobalStats.elements[elem]++;
        GlobalStats.perkPoints--;
        if(GlobalStats.perkPoints<=0){
            deactivateButtons();
        }
    }

    private void closeInventory()
    {
        elementMenue.SetActive(false);
        inventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        elementMenue.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = GlobalStats.elements[0].ToString();
        healthBar.UpdateBar(GlobalStats.health, 20);
    }
}
