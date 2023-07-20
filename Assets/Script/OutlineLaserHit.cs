using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OutlineLaserHit : MonoBehaviour
{
    private XRRayInteractor rayInteractor; // Komponen XR Ray Interactor pada kontroler tangan kiri
    private GameObject lastHitObject; // Objek terakhir yang terkena ray
    private Outline lastHitOutline; // Komponen Quick Outline pada objek terakhir yang terkena ray

    public InputActionAsset inputActions;
    private InputAction laserController;

    private void Awake()
    {
        lastHitOutline.enabled = false;
    }

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>(); // Dapatkan komponen XR Ray Interactor

        laserController = inputActions.FindActionMap("XRI LeftHand").FindAction("LaserPointer");
        laserController.Enable();
        laserController.performed += ActiveLaser;
    }

    void Update()
    {
        // Dapatkan informasi raycast dari XR Ray Interactor
        if (rayInteractor.TryGetCurrent3DRaycastHit(out var raycastHit))
        {
            // Dapatkan objek yang terkena oleh ray (laser) dari kontroler
            GameObject hitObject = raycastHit.collider.gameObject;

            // Dapatkan komponen QuickOutline pada objek yang terkena
            Outline outline = hitObject.GetComponent<Outline>();

            if (outline != null)
            {
                // Nonaktifkan efek outline pada objek terakhir jika tidak sama dengan objek yang terkena saat ini
                if (lastHitObject != hitObject)
                {
                    if (lastHitOutline != null)
                    {
                        lastHitOutline.enabled = false;
                    }

                    // Aktifkan efek outline pada objek yang terkena saat ini
                    outline.enabled = true;

                    // Simpan objek dan komponen Quick Outline terakhir
                    lastHitObject = hitObject;
                    lastHitOutline = outline;
                }
            }
            else
            {
                // Nonaktifkan efek outline pada objek terakhir jika tidak memiliki komponen Quick Outline
                if (lastHitOutline != null)
                {
                    lastHitOutline.enabled = false;
                }

                // Reset objek dan komponen Quick Outline terakhir
                lastHitObject = null;
                lastHitOutline = null;
            }
        }
        else
        {
            // Nonaktifkan efek outline pada objek terakhir jika ray tidak lagi menunjuk objek
            if (lastHitOutline != null)
            {
                lastHitOutline.enabled = false;
            }

            // Reset objek dan komponen Quick Outline terakhir
            lastHitObject = null;
            lastHitOutline = null;
        }
    }

    private void OnDestroy()
    {
        laserController.performed -= ActiveLaser;
    }

    public void ActiveLaser(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = !rayInteractor.enabled;
    }
}
