using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks 
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer() 
    {
        PhotonNetwork.ConnectUsingSettings();
        print("try connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        print("connect to server...");
        base.OnConnectedToMaster();

        //room options
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("join a room...");
        base.OnJoinedLobby();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
