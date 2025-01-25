using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelScript : MonoBehaviour
{

    public float swimSpeed;
    private bool facingLeft = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.velocity;
        currentVelocity.x = swimSpeed;
        

            if (facingLeft)
            {
                // currentVelocity.x = enemySpeed;
                currentVelocity.x *= -1;
            }
        rb.velocity = currentVelocity;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "TurnAround")
        {
            facingLeft = !facingLeft;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            BubbleScript controller = collision.gameObject.GetComponent<BubbleScript>();
            if (controller)
            {
                controller.BubblePop();
            }
        }

    }
}
