using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    void Start()
    {
        PhotonNetwork.Instantiate(Player.name,transform.position,Quaternion.identity);
    }

}
