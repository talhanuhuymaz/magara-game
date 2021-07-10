using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckButton : MonoBehaviour
{
    public float range;
    public LayerMask buttonLayer;
    public GameObject[] buttons; 

    public MyInputs controlls;

    private void Awake()
    {
        controlls = new MyInputs();
        controlls.Player.Interact.performed += ctx => Interact();
    }

    void Interact()
    {
        Debug.Log("Pressed");
        if (Physics.CheckSphere(transform.position, range, buttonLayer))
        {
            Debug.Log("Found");
            for (int i = 0; i < buttons.Length; i++)
            {
                if (Vector3.Distance(transform.position, buttons[i].transform.position) <= range)
                {
                    Debug.Log("Found 2");
                    var buttonScript = buttons[i].GetComponent<Button>();
                    buttonScript.OpenDoor();
                }
            }
        }
    }

    private void OnEnable()
    {
        controlls.Enable();
    }

    private void OnDisable()
    {
        controlls.Disable();
    }
}
