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
        playerAnim.SetFloat("Vertical", -1f);
        playerAnim.SetFloat("Horizontal", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        self.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        
        playerAnim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        playerAnim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide");
        GlobalStats.enemy = other.gameObject.GetComponent<Combatant>();
        GlobalStats.lastScene = SceneManager.GetActiveScene().buildIndex;
        GlobalStats.playerPosition = gameObject.transform.position;
        GlobalStats.enemyID = other.gameObject.GetComponent<Combatant>().id;
     
        //GlobalStats.killedEnemies.Add(other.gameObject.GetComponent<Combatant>().id);
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
}
