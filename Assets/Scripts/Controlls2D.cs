using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls2D : MonoBehaviour
{
    //Declare variables
    private float horizontal = 0f;
    private float HowFast = 15f;
    private float jumpingPower = 25f;
    
    public Animator animator;
    
    //importing important physics for the movements, and animations\\
    [SerializeField] private Rigidbody2D rb;
    
    

    //needed Ground check variables\\
    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask GroundLayer;
    private bool TouchingGround;
    
    
    
    
    //updates every frame\\
    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        TouchingGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, GroundLayer);
        //code for walking left and right\\
        //GetAxis means after the run you will gradually slow down and slide a little bit but if you use GetAxisRaw then it will instantly stop once you let go of the keys\\
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * HowFast, rb.velocity.y);
        

        


        //code for jumping mechanics\\
        if (Input.GetButtonDown("Jump") && TouchingGround == true) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        
       
        
    }

}


