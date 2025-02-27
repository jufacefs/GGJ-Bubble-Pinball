using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{   
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip audioClip;

    public int DangerType;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(audioClip);
        }
    }
}
