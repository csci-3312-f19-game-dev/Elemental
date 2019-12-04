using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public GameObject scoreObj;
    private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = scoreObj.GetComponent<TextMeshProUGUI>();
        score.text = "Score; " + GlobalStats.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
