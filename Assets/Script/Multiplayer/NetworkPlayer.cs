using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform headPos, leftHandPos, rightHandPos;

    PhotonView pView;
    private Transform headPosRig, leftHandPosRig, rightHandPosRig;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        pView = GetComponent<PhotonView>();
        XRRig rig = FindObjectOfType<XRRig>();

        headPosRig = rig.transform.FindChild("Camera Offset/Main Camera");
        leftHandPosRig = rig.transform.FindChild("Camera Offset/Left Controller");
        rightHandPosRig = rig.transform.FindChild("Camera Offset/Right Controller");
    }

    // Update is called once per frame
    void Update()
    {
        if(pView.IsMine)
        {
            rightHandPos.gameObject.SetActive(false);
            leftHandPos.gameObject.SetActive(false);
            headPos.gameObject.SetActive(false);

            MapPosition(headPos, headPosRig);
            MapPosition(leftHandPos, leftHandPosRig);
            MapPosition(rightHandPos, rightHandPosRig);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
