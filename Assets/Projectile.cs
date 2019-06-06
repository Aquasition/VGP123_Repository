using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float lifeTime;
    int damage = 1;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( (collision.gameObject.name =="Projectile1"|| collision.gameObject.name =="BillRizer"))
            {
            ;
        }
        else{
                Destroy(gameObject, 0.0f);
        }

        
    }
    
}
