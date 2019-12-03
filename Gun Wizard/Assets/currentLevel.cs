using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class currentLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshPro levelText;
    void Start()
    {
        levelText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.SetText("Current Level: "+GlobalStats.level);
    }
}
