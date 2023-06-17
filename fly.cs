using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class fly : MonoBehaviour
{
    public InputActionReference customToggleReference;
    private InputAction toggleReference;
    public Transform leftHand;
    public Transform head;
    public float flyingSpeed;
    private bool isFlying;
    private bool hasAlreadyBeenTriggered;


    private void Start()
    {
        toggleReference = customToggleReference.action;
        toggleReference.started += ToggleJetpackAction;
        toggleReference.canceled += ToggleJetpackAction;
        toggleReference.Enable();
    }


    private void Update()
    {
        if (toggleReference.ReadValue<float>() > 0f)
        {
            Thrust();
        }
    }


    private void ToggleJetpackAction(InputAction.CallbackContext context)
    {
        if (!hasAlreadyBeenTriggered)
        {
            hasAlreadyBeenTriggered = true;
            isFlying = !isFlying;
        }
    }


    private void Thrust()
    {
        if (isFlying)
        {
            Vector3 flyDirection = leftHand.transform.position - head.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(head.position, flyDirection, out hit, flyingSpeed * Time.deltaTime) && hit.transform.CompareTag("Floor")
    || Physics.Raycast(leftHand.position, flyDirection, out hit, flyingSpeed * Time.deltaTime) && hit.transform.CompareTag("Floor"))
            {
                return;
            }
            transform.position += flyDirection.normalized * Time.deltaTime * flyingSpeed;
   
        }
    }
}
