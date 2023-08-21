using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHand : MonoBehaviour
{
    private ActionBasedController actionBasedController;

    private float speed = 5.0f;

    private Animator vrHandAnimator;
    private int flexFloatID;
    private int pinchFloatID;

    private float gripCurrent, gripTarget;
    private float triggerCurrent, triggerTarget;

    // Start is called before the first frame update
    void Start()
    {
        actionBasedController = GetComponentInParent<ActionBasedController>();
        vrHandAnimator = GetComponent<Animator>();
        flexFloatID = Animator.StringToHash("Flex");
        pinchFloatID = Animator.StringToHash("Pinch");  
    }

    // Update is called once per frame
    void Update()
    {
        HandMovement();
    }

    void HandMovement()
    {
        gripTarget = actionBasedController.selectAction.action.ReadValue<float>();
        triggerTarget = actionBasedController.selectAction.action.ReadValue<float>();

        if(gripCurrent != gripTarget)
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);

        if (triggerCurrent != triggerTarget)
            triggerCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);

        vrHandAnimator.SetFloat(flexFloatID, gripCurrent);
        vrHandAnimator.SetFloat(pinchFloatID, triggerCurrent);
    }
}
