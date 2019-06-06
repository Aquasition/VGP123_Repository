using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    GameObject Bill;
    Character speedUp;
    // Start is called before the first frame update
    void Start()
    {
        Bill = GameObject.Find("BillRizer");
        speedUp = Bill.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 void OnCollisionEnter2D(Collision2D c)
    {
        if ((c.gameObject.name == "BillRizer"))
        {
            Destroy(gameObject, 0.0f);
            speedUp.speed += 0.3f;
            speedUp.jumpForce += 0.3f;
        }
        else
        {
            ;
        }
    }
}
