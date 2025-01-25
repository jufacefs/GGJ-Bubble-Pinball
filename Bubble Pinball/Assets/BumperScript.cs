using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    private Animator animator;
    public float radius;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //if hit by player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector3 explosionPos = transform.position;
            Rigidbody bubble = collision.rigidbody;
            //expand outwards, pushing away player at speed
            if (bubble != null)
            {
                bubble.AddExplosionForce(power, explosionPos, radius, 0.0F, ForceMode.VelocityChange);
            }
            //give player stunned effect?

            //slowly shrink back to normal size
            animator.SetTrigger("PlayerHit");
        }
    }
}
