using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class to control 'Character' GameObject
// - Must be attached to Character in Hierarchy
// - Handles 'Character' mechanics
// - Filename must match class name below
public class Character : MonoBehaviour {
    
    // Method 1: Keeps a reference Rigidbody2D through script
    // - Not shown in Inspector
    Rigidbody2D rb;

    public AudioSource OOF;

    public static int health = 6;

    public float speedBoost = 0.3f;
    public float jumpBoost = 0.3f;
   

    // Method 2: Keeps a reference Rigidbody2D through script
    // - Shown in Inspector

    // Handles movement speed of Character
    // - Can be adjusted through Inspector while in Play mode
    // - Used to debug movements and test the 'speed' of the Character
    public float speed;

    // Handles jump speed of Character

    // How high Character jumps
    public float jumpForce;

    // Is 'Character' on ground
    // - Are they able to jump
    // - Must be grounded to jump (aka no double jump)
    public bool isGrounded;

    // What is the Ground? 
    // - Player can only jump on GameObjects that are on "Ground" layer  
    public LayerMask isGroundLayer;

    // Tells script where to check if 'Characer' is on ground
    public Transform groundCheck;

    // Size of overlapping circle being checked against ground Colliders
    public float groundCheckRadius;

    //Tells direction going
    public bool isFacingRight;

    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    public float projectileForce;

    // Handles animation states for Character
    // - Idle, Run, Attack...etc.
    Animator anim;

	// Use this for initialization
	void Start () {

        OOF = GetComponent<AudioSource>();
        // Method 1: Save a reference of Component in script
        // - Component must be added in Inspector
        rb = GetComponent<Rigidbody2D>();
        
        // Check if Component exists
        if (!rb) // or if(rb == null)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Rigidbody2D not found on " + name);
        }

        // Method 1: Save a reference of Component in script
        // - Component must be added in Inspector
        // - Component should be dragged into variable in Script through Inspector
        if (!rb)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Rigidbody2D not found on " + name);
        }

        // Check if variable is set to something not 0
        if (speed <= 0)
        {
            // Set a default value to variable if not set in Inspector
            speed = 5.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("Speed not set on " + name + ". Defaulting to " + speed);
        }

        // Check if variable is set to something not 0
        if (jumpForce <= 0)
        {
            // Set a default value to variable if not set in Inspector
            jumpForce = 5.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("JumpForce not set on " + name + ". Defaulting to " + jumpForce);
        }

        // Check if variable is set to something
        if (!groundCheck) 
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("GroundCheck not found on " + name);
        }

        // Check if variable is set to something not 0
        if (groundCheckRadius <= 0)
        {
            // Set a default value to variable if not set in Inspector
            groundCheckRadius = 0.2f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("GroundCheckRadius not set on " + name + ". Defaulting to " + groundCheckRadius);
        }

        // Save a reference of Component in script
        // - Component must be added in Inspector
        anim = GetComponent<Animator>();
        
        // Check if Component exists
        if (!anim) 
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Animator not found on " + name);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        /*if(health == 0)
        {
            Destroy(gameObject);
        }*/
        // Checks if Left (or a) or Right (or d) is pressed
        // - "Horizontal" must exist in Input Manager (Edit-->Project Settings-->Input)
        // - Returns -1(left), 1(right), 0(nothing)
        // - Use GetAxis for value -1-->0-->1 and all decimal places. (Gradual change in values)
        float moveValue = Input.GetAxisRaw("Horizontal");

        // Check if 'groundCheck' GameObject is touching a Collider on Ground Layer
        // - Can change 'groundCheckRadius' to a smaller value for better precision or if 'Character' is smaller or bigger
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 
            groundCheckRadius, isGroundLayer);

        // Check if "Jump" button was pressed
        // - "Jump" must exist in Input Manager (Edit-->Project Settings-->Input)
        // - Configuration can be changed later
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("Jump");
            

            // Zeros out force before applying a new force
            // - If force is not zeroed out, the force of gravity will have an effect on the jump
            // - Not setting velocity to 0
            //   - Gravity is -9.8 and force up would be 5 causing a force of -4.8 to be applied
            // - Setting velocity to 0
            //   - Gravity is reset to and force up would be 5 causing a force of 5.0 to be applied
            rb.velocity = Vector2.zero;

            // Unit Vector shortcuts that can be used
            // - Vector2.up --> new Vector2(0,1);
            // - Vector2.down --> new Vector2(0,-1);
            // - Vector2.right --> new Vector2(1,0);
            // - Vector2.left --> new Vector2(-1,0);

            // Applies a force in the UP direction
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Check if Left Control was pressed
        if (Input.GetButtonDown("Fire1"))
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("Pew pew");
           fire();
        }
        // Move Character using Rigidbody2D
        // - Uses moveValue from GetAxis to move left or right
        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);

        // Tells Animator to transition to another Clip
        // - Parameter must be created in Animator window under Parameter tab
        anim.SetFloat("speed", Mathf.Abs(moveValue));
        anim.SetFloat("jumpForce", Mathf.Abs(jumpForce));
        

        bool h = Input.GetButton("Jump");
        bool v = Input.GetButton("Vertical");
        bool d = Input.GetButton("Fire2");
        bool launch = Input.GetButton("Fire1");
        anim.SetBool("LookUp", v);
        anim.SetBool("LookDown", d);
        anim.SetBool("spaceBar", h);
        anim.SetBool("Fire", launch);

        if((isFacingRight && moveValue > 0)||(!isFacingRight && moveValue < 0) )
        {
            flip();
        }
    }
    
        void flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;

        transform.localScale = scaleFactor;
    }
   void fire()
    {
        Projectile temp =
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        if (!isFacingRight)
            temp.speed = projectileForce * (-1);
        else
            temp.speed = projectileForce;
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Collectable")
        {
            jumpForce += jumpBoost;
            speed += speedBoost;
            Destroy(c.gameObject);
            ShowScore.ssccoorree += 25;
        }
        if (c.gameObject.name == "Laser3(Clone)")
        {
            Destroy(c.gameObject);
            health -= 1;
            OOF.Play();
        }
        
    }
    
    
       
    
}
