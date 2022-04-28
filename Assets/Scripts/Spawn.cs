using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject Player, ChatManager;

    void Start()
    {
        PhotonNetwork.Instantiate(Player.name,transform.position,Quaternion.identity);
        PhotonNetwork.Instantiate(ChatManager.name, transform.position, Quaternion.identity);
    }

}
