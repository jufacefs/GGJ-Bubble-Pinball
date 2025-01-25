using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{

    public int DangerType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider collision)
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
