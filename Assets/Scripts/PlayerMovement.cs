using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speed;
    public float playerJumpForce;
    SpriteRenderer sprite;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * playerJumpForce);
            animator.SetTrigger("IsJumping");
        }
        if(movement.x>0)
        {
            sprite.flipX = false;
           animator.SetTrigger("IsRunning");
        }
        else if(movement.x<0)
        {
            sprite.flipX = true;
            animator.SetTrigger("ToIdle");  
        }

        rb.velocity = new Vector3(movement.x * speed * Time.deltaTime, 0, 0);
        


    }
}
