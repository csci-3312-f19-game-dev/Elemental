using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenueManager : MonoBehaviour
{
    public GameObject elementMenue;
    public SimpleHealthBar healthBar;
    private bool inventoryOpen;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI XPText;
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
        LevelText.SetText("Current Level: " + GlobalStats.level);
        XPText.SetText("XP Needed to Level Up: " + (GlobalStats.level * 5-GlobalStats.exp) + "/" + (GlobalStats.level*5));
        updateElement();
        healthBar.UpdateBar(GlobalStats.health, 20);
    }

    private void updateElement()
    {
        for (int i = 0; i < 5; i++)
        {
            elementMenue.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = GlobalStats.elements[i].ToString();
        }
    }
}
