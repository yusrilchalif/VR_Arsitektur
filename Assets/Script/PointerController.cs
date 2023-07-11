using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerController : MonoBehaviour
{
    [SerializeField] LineRenderer pointerLaser;

    private XRController controller;
    bool isLaserActive = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.IsPressed(InputHelpers.Button.PrimaryButton, out bool isPressed))
        {
            if(isPressed)
            {
                ToogleLaserPointer();
            }
        }    
    }

    void ToogleLaserPointer()
    {
        isLaserActive = !isLaserActive;
        pointerLaser.enabled = isLaserActive;
    }
}
