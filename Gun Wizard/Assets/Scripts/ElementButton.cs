using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject arrow1;
    private GameObject arrow2;
    void Start()
    {
        arrow1 = transform.Find("Arrow1").gameObject;
        arrow2 = transform.Find("Arrow2").gameObject;
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
}
