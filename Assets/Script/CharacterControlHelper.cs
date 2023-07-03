using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterControlHelper : MonoBehaviour
{
    XRRig rig;
    CharacterController characterController;
    CharacterControllerDriver driver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCharacterController();
    }

    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (rig == null || characterController == null)
            return;

        var height = Mathf.Clamp(rig.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = rig.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
    }
}
