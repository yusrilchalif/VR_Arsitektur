using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PointerController : MonoBehaviour
{
    public XRController controller;
    public XRRayInteractor rayInteractor;

    private bool isRayInteractorEnabled = true;

    private void Update()
    {
        // Mendapatkan input dari tombol Axis2D SecondaryButton pada kontroler Oculus Quest
        bool secondaryButtonPressed = controller.inputDevice.IsPressed(InputHelpers.Button.Secondary2DAxisClick);

        // Mengubah status RayInteractor berdasarkan input tombol Axis2D SecondaryButton
        if (secondaryButtonPressed)
        {
            isRayInteractorEnabled = !isRayInteractorEnabled;
            rayInteractor.enabled = isRayInteractorEnabled;
        }
    }
}
