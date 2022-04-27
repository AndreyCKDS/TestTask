using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField Input;
    private RoomOptions RoomOptions;
    public void CreateRoom()
    {
        RoomOptions = new RoomOptions();
        RoomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(Input.text, RoomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(Input.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
