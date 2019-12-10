using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] removables;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlock()
    {
        foreach (GameObject obj in removables)
        {
            obj.SetActive(false);
        }
            
    }
}
