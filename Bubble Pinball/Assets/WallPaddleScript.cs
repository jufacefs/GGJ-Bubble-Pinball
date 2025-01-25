using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaddleScript : MonoBehaviour
{

    private Animator animator;
    public bool pushing;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Push();
        }
    }


    private void Push()
    {
        animator.SetTrigger("PushInput");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (pushing == true)
            {
                Rigidbody bubble = collision.gameObject.GetComponent<Rigidbody>();
                bubble.AddForce(transform.right * force);
            }
        }
    }
}
