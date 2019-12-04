using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Animator playerAnim;
    private Rigidbody2D self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        playerAnim.SetTrigger("down");
    }

    // Update is called once per frame
    void Update()
    {
        self.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        float velx = self.velocity.x;
        float vely = self.velocity.y;


        if (Input.GetAxis("Vertical") < 0)
        {
            playerAnim.SetTrigger("down");
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetTrigger("right");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnim.SetTrigger("left");
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            playerAnim.SetTrigger("up");
        }



    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide");
        GlobalStats.enemy = other.gameObject.GetComponent<Combatant>();
        GlobalStats.lastScene = SceneManager.GetActiveScene().buildIndex;
        GlobalStats.playerPosition = gameObject.transform.position;
        if(other.gameObject.tag == "boss")
        {
            GlobalStats.enemyID = 10;
        }
        else
        {
            GlobalStats.enemyID = 1;
        }
        //GlobalStats.killedEnemies.Add(other.gameObject.GetComponent<Combatant>().id);
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
}
