using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float playerSpeed = 3f;
    Vector2 movementInput;
    Vector2 mousePos;

    public Rigidbody2D rb;

    public SpriteRenderer playerSprite;
  

    private void Update()
    {
        //Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

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
        rb.MovePosition(rb.position + movementInput * playerSpeed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2((mousePos - rb.position).y, (mousePos - rb.position).x) * Mathf.Rad2Deg - 90f;
        
    }


}
