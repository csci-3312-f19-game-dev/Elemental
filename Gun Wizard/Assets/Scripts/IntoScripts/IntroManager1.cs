using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroManager1 : MonoBehaviour
{
    public int frame;
    public Button continueButton;
    public GameObject elementMenue;
    public GameObject textBox;
    public GameObject player;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
        text = textBox.GetComponent<TextMeshProUGUI>();
        player.SetActive(false);
        elementMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuePress()
    {
        if (frame == 0)
        {
            player.SetActive(true);
            text.text = "You are a gun weilding wizard. This is you";
            frame = 1;
            return;
        }
        if( frame == 1)
        {
            text.text = "Your goal is to defeat enemies and clear the dungeon";
            frame = 2;
            return;
        }
        if(frame == 2)
        {
            text.text = "In combat you have 3 stats; Health, Ammo, and Sheilds";
            frame = 3;
            return;
        }
        if(frame == 3)
        {
            elementMenue.SetActive(true);
            text.text = "Combat has 2 rounds. First you pick your element, then you pick your action";
            frame = 4;
            return;
        }
        if(frame == 4)
        {
            text.text = "Each element is super effective againts 2 others, and weak agains the remaining 2";
            frame = 5;
            return;
        }
        if(frame == 5)
        {
            text.text = "Good Luck.";
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Begin Adventure";
            frame = 6;
            return;
        }
        if(frame == 6)
        {
            SceneManager.LoadScene(2);
        }
    }
}
