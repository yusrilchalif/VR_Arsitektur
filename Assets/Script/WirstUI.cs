using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WirstUI : MonoBehaviour
{
    public InputActionAsset inputActions;

    private Canvas wristCanvas;
    private InputAction menu;

    // Start is called before the first frame update
    void Start()
    {
        wristCanvas = GetComponent<Canvas>();
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menu.Enable();
        menu.performed += ToogleMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        menu.performed -= ToogleMenu;
    }

    public void ToogleMenu(InputAction.CallbackContext context)
    {
        wristCanvas.enabled = !wristCanvas.enabled;
    }
}
