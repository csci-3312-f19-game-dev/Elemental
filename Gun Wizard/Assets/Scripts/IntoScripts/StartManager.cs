using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
    public Button startButton;
    public Button introButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButtonPress()
    {
        SceneManager.LoadScene(2);
    }
    public void introButtonPress()
    {
        SceneManager.LoadScene(1);
    }
}
