using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG;
using DG.Tweening;

public class ButtonHotspotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject panelInformation;
    public Transform target;
    public Vector3 panelPosition = new Vector3(0, 1.5f, 0);

    private Quaternion initialQuaternion;
    private LineRendererController lineRendererController;

    // Start is called before the first frame update
    void Start()
    {
        panelInformation.SetActive(false);
        initialQuaternion = transform.rotation;

        lineRendererController = GetComponent<LineRendererController>();
        lineRendererController.DisableLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            panelInformation.transform.position = target.position + panelPosition;
            lineRendererController.SetLinePoints(transform.position, target.position);
        }
        else
        {
            //reset position
            transform.rotation = initialQuaternion;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.22f), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerExit(eventData);
        TogglePopUp();
    }

    void TogglePopUp()
    {
        if (panelInformation.activeSelf)
        {
            panelInformation.SetActive(false);
            lineRendererController.DisableLine();
        }
        else
        {
            panelInformation.SetActive(true);
            lineRendererController.EnableLine();
        }
    }
    
}
