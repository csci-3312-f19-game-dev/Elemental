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
            text.text = "You are a gun wielding wizard. This is you";
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
            text.text = "In combat you have 3 stats; Health, Ammo, and Shields";
            frame = 3;
            return;
        }
        if(frame == 3)
        {
            elementMenue.SetActive(true);
            text.text = "Combat has 2 rounds. First you pick your element";
            frame = 4;
            return;
        }
        if (frame == 4)
        {
            text.text = "Each element is super effective against 2 others, and weak against the remaining 2";
            frame = 5;
            return;
        }
        if (frame == 5)
        {
            text.text = "Next you choose your action";
            frame = 6;
            return;
        }
        if (frame == 6)
        {
            text.text = "Damage outcomes are calculated based on BOTH the element and action chosen";
            frame = 7;
            return;
        }
        if (frame == 7)
        {
            text.text = "Both you and the enemy will change color based on the previous element chosen";
            player.GetComponent<SpriteRenderer>().color = new Color(250,0,0);
            frame = 8;
            return;
        }
        if (frame == 8)
        {
            text.text = "Your final score is: Remaining Health * Points from defeating enemies. Play smart and conserve health to get a high score!";
            frame = 9;
            return;
        }
        if (frame == 9)
        {
            text.text = "Good Luck. - Make sure to level up right away ;)";
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Begin Adventure";
            frame = 10;
            return;
        }
        if(frame == 10)
        {
            SceneManager.LoadScene(2);
        }
    }
}
