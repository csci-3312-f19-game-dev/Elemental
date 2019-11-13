using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = Player.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y, gameObject.transform.position.z);
    }
}
