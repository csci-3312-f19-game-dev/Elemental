using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        self.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide");
        GlobalStats.enemy = other.gameObject.GetComponent<Combatant>();
        GlobalStats.lastScene = SceneManager.GetActiveScene().buildIndex;
        GlobalStats.playerPosition = gameObject.transform.position;
        //GlobalStats.killedEnemies.Add(other.gameObject.GetComponent<Combatant>().id);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
