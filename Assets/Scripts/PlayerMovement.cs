using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerJumpForce;
    float inputX, inputY;
    public int playerSpeed;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer render;
    public int score;
    public Text scoreText;
    public Text Won;
    public bool isGrounded=true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       anim.SetTrigger("ToIdle");
        if (isGrounded == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetTrigger("IsJumping");
                rb.AddForce(Vector2.up * playerJumpForce);
                isGrounded = false;
            }
        }
            if(Input.GetKeyUp(KeyCode.RightAlt))
        {
            anim.SetTrigger("IsAttacking");
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            anim.SetTrigger("IsSliding");
        }
        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * playerSpeed * Time.deltaTime, rb.velocity.y);
        if (inputX > 0 || inputX < 0)
        {
            anim.SetTrigger("IsRunning");
        }
        if (inputX > 0)
        {
            render.flipX = false;
        }
        if (inputX < 0)
        {
            render.flipX = true;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Gems")
        {
            Destroy(collision.gameObject);
            score = score + 10;
            scoreText.text= score.ToString();
            if(score==50)
            {
                Won.GetComponent<Text>().enabled = true;
               
            }
            
        }
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
        }
    }



}