using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource DD;
    BoxCollider2D cder;
    Rigidbody2D spr;
    Animator anim;
    public int health;
    public Rigidbody2D rb;
    public bool isFacingRight;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        DD = GetComponent<AudioSource>();
        cder = GetComponent<BoxCollider2D>();
        spr = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (health <= 0) 
        {
            health = 5;
            Debug.Log("Enemy: Defaulting HP to" + health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag != "Ground")
        {
            flip();
        }
        if (c.gameObject.name == "BillRizer")
        {
            Character.health -=4;
        }
        
    }
        private void OnTriggerEnter2D(Collider2D d)
    {
            if (d.gameObject.name == "Projectile1(Clone)")
            {
                Destroy(d.gameObject);
                health -= 1;
                if (health <= 0)
                {    
                ShowScore.ssccoorree += 50;
                cder.enabled = false;
                DD.Play();
                Destroy(gameObject, 2.5f);
                }
            }
        }
 void flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;

        transform.localScale = scaleFactor;
    }
}
   
    


