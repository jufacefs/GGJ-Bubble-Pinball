using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    public float bubbleSpeed;




    // Start is called before the first frame update
    void Start()
    {

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
        Destroy(this.gameObject);
    }
}
