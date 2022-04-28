using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField RoomInput;
    [SerializeField] private TMP_InputField NameInput;
    private RoomOptions RoomOptions;

    private void Start()
    {
        NameInput.text = PlayerPrefs.GetString("Name");
        PhotonNetwork.NickName = NameInput.text;
    }
    public void CreateRoom()
    {
        RoomOptions = new RoomOptions();
        RoomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RoomInput.text, RoomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("Name", NameInput.text);
        PhotonNetwork.NickName = NameInput.text;
    }
}
