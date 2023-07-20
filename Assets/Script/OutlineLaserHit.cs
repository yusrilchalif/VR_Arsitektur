using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OutlineLaserHit : MonoBehaviour
{
    private XRRayInteractor interactor;

    private void Start()
    {
        interactor = GetComponent<XRRayInteractor>();
    }

    private void Update()
    {
        if(interactor.TryGetCurrent3DRaycastHit(out var raycastHit))
        {
            GameObject hitObject = raycastHit.collider.gameObject;

            Outline outline = hitObject.GetComponent<Outline>();

            if(outline != null)
            {
                outline.enabled = true;
            }
        }
    }
}
