using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerController : MonoBehaviour
{
    [SerializeField] LineRenderer pointerLaser;

    private XRController controller;
    bool isLaserActive = false;

    private GameObject currentHitObject;
    private OutlineLaserHit laserHit;

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

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if(hitObject != currentHitObject)
            {
                if(laserHit != null)
                {
                    laserHit.OnPointerExit(null);
                }

                laserHit = hitObject.GetComponent<OutlineLaserHit>();
                if(laserHit != null)
                {
                    laserHit.OnPointerEnter(null);
                }
                currentHitObject = hitObject;
            }
        }
        else
        {
            if(laserHit != null)
            {
                laserHit.OnPointerExit(null);
                laserHit = null;
            }
            currentHitObject = null;
        }
    }

    void ToogleLaserPointer()
    {
        isLaserActive = !isLaserActive;
        pointerLaser.enabled = isLaserActive;
    }
}
