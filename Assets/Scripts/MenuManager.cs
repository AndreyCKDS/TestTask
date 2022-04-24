using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField CreateInput;
    [SerializeField] private TMP_InputField JoinInput;
    private RoomOptions RoomOptions;
    public void CreateRoom()
    {
        RoomOptions = new RoomOptions();
        RoomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(CreateInput.text, RoomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
