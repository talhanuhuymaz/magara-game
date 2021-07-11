using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckButton : MonoBehaviour
{
    public Transform holdPoint;
    public float range;
    public LayerMask buttonLayer;
    public GameObject[] buttons;
    public GameObject[] cubes;

    public MyInputs controlls;

    private GameObject currentCube;

    private void Awake()
    {
        controlls = new MyInputs();
        controlls.Player.Interact.performed += ctx => Interact();
    }

    void Interact()
    {
        // Droping the cube
        if (currentCube != null)
        {
            Rigidbody cubeRb = currentCube.GetComponent<Rigidbody>();
            cubeRb.isKinematic = false;
            currentCube.transform.SetParent(null);
            currentCube = null;
            return;

        }

        // Checking for buttons
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
        // Cheking for cubes
        if (Physics.CheckSphere(transform.position, range, buttonLayer))
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                if (Vector3.Distance(transform.position, cubes[i].transform.position) <= range)
                {
                    currentCube = cubes[i];
                    Rigidbody cubeRb = currentCube.GetComponent<Rigidbody>();
                    cubeRb.isKinematic = true; // making the rb kinematic so it wont fall
                    currentCube.transform.position = holdPoint.position;
                    currentCube.transform.SetParent(holdPoint);
                    
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
