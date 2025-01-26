using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    public float bubbleSpeed;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBubble();
    }


    // controls direction of bubble motion
    public void MoveBubble()
    {
        //initialize current position
        Vector3 currentPos = transform.position;
        //set x value
        currentPos.x = currentPos.x + (Input.GetAxisRaw("Horizontal") * bubbleSpeed * Time.deltaTime);
        //update x value
        transform.position = currentPos;
    }

    public void BubblePop()
    {
        Debug.Log("Player Killed");
        GameManagerScript.S.PlayerDeath();
        StartCoroutine(PopIt());

    }

    public IEnumerator PopIt()
    {
        animator.SetTrigger("PlayerDies");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
