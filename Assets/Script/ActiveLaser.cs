using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ActiveLaser : MonoBehaviour
{
    public InputActionAsset inputActions;

    [SerializeField] private OutlineLaserHit laserHit;
    [SerializeField] TextMeshProUGUI laserCondition;
    private InputAction activeLaser;

    // Start is called before the first frame update
    void Start()
    {
        laserHit = GetComponent<OutlineLaserHit>();

        activeLaser = inputActions.FindActionMap("XRI RightHand").FindAction("ActiveLaser");
        activeLaser.Enable();
        activeLaser.performed += ToggleLaser;
    }

    private void OnDestroy()
    {
        activeLaser.performed -= ToggleLaser;
    }

    public void ToggleLaser(InputAction.CallbackContext context)
    {
        print("Check Laser");
        laserHit.enabled = !laserHit.enabled;

        laserCondition.text = "Outline Bangunan " + (laserHit.enabled ? "Aktif" : "Tidak Aktif");
    }
}
