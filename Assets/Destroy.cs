using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destroy : MonoBehaviour
{

    float health = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject, 0.0f);
        }

    }

   private void OnTriggerEnter2D(Collider2D c)
    {
        if ((c.gameObject.name == "Projectile1"))
        {
            health = health -= 0.5f;
        }
        else
        {
            ;
        }
    }

}
