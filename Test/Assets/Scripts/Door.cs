using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IDoor
{
    private Animator animator;
    private int animatorBoolHash;
    private bool isOpen;
    public Key key;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorBoolHash = Animator.StringToHash("character_nearby");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            if (key != null)
            {
                foreach (var item in KeyManager.instance.haveKeys)
                {
                    if (item == key)
                    {
                        OpenDoor();
                    }
                }
            }
            else
            {
                OpenDoor();
            }
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen) 
        {
            CloseDoor();
            
        }
    }

    public void CloseDoor()
    {
        animator.SetBool(animatorBoolHash, false);
        isOpen = false;
    }

    public void OpenDoor()
    {
        isOpen = true;
        animator.SetBool(animatorBoolHash, true);
    }
    

   

}
