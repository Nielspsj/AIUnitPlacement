using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//vTest 1: Movement
//vTest 2: Rigibody gravity
//vTest 3: Ground checker
//vTest 4: Jump
//vTest 5: Flip sprite to direction
//Test 6: Vertical movement "upwards"
public class TopDownController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float speed = 8f;
    private float horizontal;
    private float vertical;
    private Vector2 movementDirection;
    private bool isFacingRight = true;

    private void Awake()
    {
        //Grab a reference before we start doing anything.
        rb2D = GetComponent<Rigidbody2D>();
    }
  
    // Update is called once per frame
    void Update()
    {
        InputController();

        //Debug.Log("ground: " + isGrounded());
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void InputController()
    {
        //Store horizontal input (-1 is left, 1 is right).
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Normalize so we move the same amount in all directions.
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }

    private void MovePlayer()
    {
        //Physics movement should be in FixedUpdate
        rb2D.velocity = new Vector2(movementDirection.x * speed, movementDirection.y * speed);
    }

    //Flip the scale instead of the sprite.
    //Just in case there are lots of sprites that also should be flipped.
    private void FlipPlayer()
    {        
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }        
    }
}
