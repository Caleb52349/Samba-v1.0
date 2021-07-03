using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumpForce;
    private float moveInput;
  private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisGround;

    private int extraJump;
    public int extraJumpValue;
    //stats
    public int  curHealth;
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }


    public void Damage(int dmg)
        {
            curHealth -= dmg;
        }
    


 void Update()
    {

         if(isGrounded == true)
        {
            extraJump = extraJumpValue;
        }  


        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

   
}
