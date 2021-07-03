using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    //stats
    public int curHealth;
    public int maxHealth;

    public bool isDead ;
    //GameOverPanel
   
    public GameObject GameOverPanel;

    //Pause

    public PauseControl pc;
    //Ground check
    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 400f);
        soundManagerScript.PlaySound("jump");




        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
        {
           
            anim.SetBool("isJumping", true);
          
        }
      
     
        if (rb.velocity.y <0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        //Game is over
        if(curHealth <=0 )
         {
            isDead = true;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
          
        }
    
       else 
        {
            isDead = false;
            
        }
     
        

    }
    
    //Player absorbs coin and coin object gets destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }

    }
    
        private void FixedUpdate()
    {
         rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    //Update to algin player facing left or right
    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if(dirX < 0)
        facingRight = false;


        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
     /* void Die()

    {
       
        //Restarts the Game

        //Application.LoadLevel(Application.loadedLevel);
    }
     */
    //Damage counter and Animation effect when player is hurt
    public void Damage(int dmg)
    {
        curHealth = curHealth-dmg;
        gameObject.GetComponent<Animation>().Play("HurtAnimation");
        soundManagerScript.PlaySound("playerHit");

       
    }
    
    //knockback effect 
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }

        yield return 0;
    }
}