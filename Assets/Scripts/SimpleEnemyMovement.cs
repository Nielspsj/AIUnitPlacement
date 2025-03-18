using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SimpleEnemyMovement : MonoBehaviour
{
    //Variables for the transform component of the player and speed of the enemy.
    private Transform player;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Player when we start running the scene.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Always move. In its own method to not make Update cluttered.
        Movement();
    }

    //Move towards the player. Player could be any other target.
    //Move with our set speed.
    //Smooth the movement with Time.deltaTime.
    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //This if you want to go straight at an angle:
        //transform.Translate(transform.right * speed * Time.deltaTime); 
    }
}
