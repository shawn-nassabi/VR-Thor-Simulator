using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HammerConnection : MonoBehaviour
{

    public InputActionReference rightPrimaryButton;
    public Mjolnir hammer;

    // Start is called before the first frame update
    void Start()
    {
        rightPrimaryButton.action.performed += PrimaryButtonPressed;
    }


    
    void PrimaryButtonPressed(InputAction.CallbackContext context)
    {
        hammer.ReturnHammer();
    }

}
