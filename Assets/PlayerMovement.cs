using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed, playerJumpForce,playerRadius;
    Rigidbody2D rb;
    bool facingRight;
    public bool isGrounded;
    public LayerMask layerMask;
    public int jumps, maxnumberOfJumps;
    public Transform groundCheck;
    float xinput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        jumps = maxnumberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            jumps = maxnumberOfJumps;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerRadius, layerMask);
        xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * playerSpeed, rb.velocity.y);


        if (facingRight==false&&xinput>0)
        {
            Flip();
        }
        else if (facingRight == true && xinput < 0)
        {
            Flip(); 
        }
        if (Input.GetButtonDown("Jump") && jumps>0)
        {
            rb.velocity = Vector2.up*playerJumpForce;
            maxnumberOfJumps -=1;
        }
        if (Input.GetButtonDown("Jump") && jumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * playerJumpForce;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180.0f, 0);
    }
   public  void SuperJump()
    {
        rb.velocity = Vector2.up * playerJumpForce*1.25f;
    }
}
