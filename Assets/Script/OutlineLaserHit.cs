using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineLaserHit : MonoBehaviour
{
    public string targetTag = "Interactable"; // Ganti "YourTargetTag" dengan tag yang ingin Anda targetkan

    private XRInteractorLineVisual lineVisual;
    private Outline outlineScript;
    private GameObject currentHitObject;

    private void Awake()
    {
        lineVisual = GetComponent<XRInteractorLineVisual>();
    }

    private void Start()
    {
        // Mengatur efek outline menjadi mati (false) pada awalnya
        outlineScript = GetComponent<Outline>();
        if (outlineScript != null)
        {
            Destroy(outlineScript);
        }
    }

    private void Update()
    {
        // Membuat ray dari posisi laser pointer
        Ray ray = new Ray(lineVisual.transform.position, lineVisual.transform.forward);

        // Mendeteksi apakah laser pointer mengenai objek dengan tag yang sesuai
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(targetTag))
        {
            GameObject hitObject = hit.collider.gameObject;

            // Jika objek yang terkena laser berbeda dari sebelumnya
            if (hitObject != currentHitObject)
            {
                // Matikan efek outline pada objek sebelumnya
                if (currentHitObject != null)
                {
                    ClearOutlineEffect(currentHitObject);
                }

                // Terapkan efek outline pada objek yang baru terkena laser
                outlineScript = hitObject.GetComponent<Outline>();
                if (outlineScript == null)
                {
                    outlineScript = hitObject.AddComponent<Outline>();
                    outlineScript.OutlineWidth = 5f; // Sesuaikan ketebalan outline sesuai keinginan Anda
                }

                currentHitObject = hitObject;
            }
        }
        else
        {
            // Jika laser keluar dari objek, matikan efek outline pada objek sebelumnya
            if (currentHitObject != null)
            {
                ClearOutlineEffect(currentHitObject);
                currentHitObject = null;
            }
        }
    }

    private void ClearOutlineEffect(GameObject obj)
    {
        // Hapus script Outline dan efek outline dari objek yang diberikan
        var outlineScript = obj.GetComponent<Outline>();
        if (outlineScript != null)
        {
            Destroy(outlineScript);
        }
    }
}
