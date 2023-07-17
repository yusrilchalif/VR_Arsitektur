using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationController : MonoBehaviour
{
    static private bool isTeleportActive = false;
    public enum ControllerType
    {
        RightHand,
        LeftHand
    }

    public ControllerType targetController;
    public InputActionAsset inputActions;
    public XRRayInteractor rayInteractor;
    public TeleportationProvider teleportationProvider;

    private InputAction thumbstickInput;
    private InputAction teleportActive;
    private InputAction teleportCancel;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        //Check teleport active
        Debug.Log("XRI " + targetController.ToString());
        teleportActive = inputActions.FindActionMap("XRI " + targetController.ToString()).FindAction("Teleport Mode Action");
        teleportActive.Enable();
        teleportActive.performed += OnTeleportActive;

        //check teleport disable
        teleportCancel = inputActions.FindActionMap("XRI " + targetController.ToString()).FindAction("Teleport Mode Cancel");
        teleportCancel.Enable();
        teleportCancel.performed += OnTeleportCancel;

        //thumbstick controller
        thumbstickInput = inputActions.FindActionMap("XRI " + targetController.ToString()).FindAction("Move");
        thumbstickInput.Enable();
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        if(!isTeleportActive && rayInteractor == true)
        {
            rayInteractor.enabled = false;
            isTeleportActive = false;
        }
    }

    private void OnTeleportActive(InputAction.CallbackContext context)
    {
        if(!isTeleportActive)
        {
            rayInteractor.enabled = true;
            isTeleportActive = true;
        }
    }

    private void OnDestroy()
    {
        teleportActive.performed -= OnTeleportActive;
        teleportCancel.performed -= OnTeleportCancel;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTeleportActive)
            return;
        if (!rayInteractor.enabled)
            return;
        if (thumbstickInput.triggered)
            return;
        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            isTeleportActive = false;
            return;
        }

        TeleportRequest teleportRequest = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        teleportationProvider.QueueTeleportRequest(teleportRequest);

        rayInteractor.enabled = false;
        isTeleportActive = false;
    }
}
