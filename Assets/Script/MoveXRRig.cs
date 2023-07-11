using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveXRRig : MonoBehaviour
{
    public Transform spawnPointPosition;
    [SerializeField] GameObject XRRig;

    // Start is called before the first frame update
    void Start()
    {
       // Invoke("MoveAvatar", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveAvatar()
    {
        XRRig.transform.position = spawnPointPosition.position;
    }
}
