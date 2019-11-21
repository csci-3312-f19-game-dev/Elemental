using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInit : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Combatant>().id = id;
        Debug.Log("id set 1 :" + gameObject.GetComponent<Combatant>().id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
