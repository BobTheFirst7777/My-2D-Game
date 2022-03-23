using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float playerHealth;


    float playerSpeed = 5f;
    Vector2 movementInput;
    public Vector2 mousePos;


    public Rigidbody2D rb;

    public SpriteRenderer playerSprite;

    public float angle;

    Vector2 normalizedMovementInput;



    private void Update()
    {
        //Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        normalizedMovementInput = movementInput.normalized;


        //Animation
        if(movementInput.x == 1)
        {
            playerSprite.flipX = false;
        }
        else if(movementInput.x == -1)
        {
            playerSprite.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + normalizedMovementInput * playerSpeed * Time.fixedDeltaTime);

        angle = Mathf.Atan2((mousePos - rb.position).y, (mousePos - rb.position).x) * Mathf.Rad2Deg - 90f;
        
    }



}
