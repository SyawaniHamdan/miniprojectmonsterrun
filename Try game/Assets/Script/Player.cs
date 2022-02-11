using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementSpeed;
    private bool facingRight;
    private Animator myAnimator;
    
    [SerializeField]
    private Transform[] groundPoint;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;
    
    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;
    public GameObject[] players;

    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStart();
        players = GameObject.FindGameObjectsWithTag("Calver");

        if(players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(horizontal);
        
        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleLayers();

        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        if(myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land",true);
        }
        //myRigidbody.velocity = Vector2.left;   //x=-1, y=0;
        if(isGrounded || airControl)
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); 
        }
        
        //run
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

        if(isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0,jumpForce));
            myAnimator.SetTrigger("jump");
            SoundManager.PlaySound("pJump");
        }
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal <0 && facingRight)
        {
            //flip to right
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }
    
    private bool IsGrounded()
    {
        if(myRigidbody.velocity.y <=0)
        {
            //check if velocity below 0 , falling down kalau tak berdiri kat ground
            foreach (Transform point in groundPoint)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for(int i=0; i<colliders.Length; i++)
                {
                    //check collider with other or not
                    if(colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land",false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if(!isGrounded)
        {
            //pegi kat air layer
            myAnimator.SetLayerWeight(1,1);
        }
        else
        {
            myAnimator.SetLayerWeight(1,0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("goal"))
        {
            Debug.Log("Ouch");
            SoundManager.PlaySound("pDie");
            endgame();
            SceneManager.LoadScene("GameOver");
        }
        if(collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("ops!");
            SoundManager.PlaySound("pDie");
            AcessScoring.Instance.score -= 10;
           // AcessScoring.Instance2.score -= 10;
        }

    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.CompareTag("Spike"))
        {
            Debug.Log("auch!");
            SoundManager.PlaySound("pDie");
            AcessScoring.Instance.score -= 5;
        }
        
    }

    void endgame()
    {
        LoginTenenet.Instance.PlayerActivity(AcessScoring.Instance.MainName);
    }
    
    void FindStart()
    {
        transform.position = GameObject.FindWithTag("Start").transform.position;
    }

}
