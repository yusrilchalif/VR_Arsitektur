using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlaywerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayer;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayer = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}
