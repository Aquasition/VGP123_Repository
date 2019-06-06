using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public float fireRate;
    public Rigidbody2D projectilePrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public bool shootLeft;
    public GameObject target = null;
    private float timeSinceLastFire = 0;
    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.FindWithTag("BillRizer");

            shootDirectionCheck();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //fireProjectile();

    }
    void flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;

        transform.localScale = scaleFactor;
    }
    void shootDirectionCheck()
    {
        if (target.transform.position.x < transform.position.x)
        {
            if (isFacingRight)
            {
                flip();
            }
            shootLeft = true;

        }
        else
        {
            if (!isFacingRight)
            {
                flip();
            }
            shootLeft = false;

        }
    }
    void fireProjectile()
    {
        shootDirectionCheck();
        if (shootLeft)
        {
            Instantiate(projectilePrefab, rightSpawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else
        {
            Instantiate(projectilePrefab, rightSpawnPoint.position, Quaternion.Euler(new Vector3(0, 180.0f, 0)));
        }
    }
     private void OnTriggerStay2D(Collider2D c)
        {
            if (c.gameObject.name == "BillRizer")
            {
                if (Time.time > timeSinceLastFire + fireRate)
                {
                    fireProjectile();

                    timeSinceLastFire = Time.time;
                }
            }
        }
    
}
   

