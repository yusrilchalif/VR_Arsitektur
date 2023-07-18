using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineLaserHit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
}
