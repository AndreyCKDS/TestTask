using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ClothesButton : MonoBehaviourPunCallbacks
{
    private Image ButtonImage;
    private bool Equip;
    [SerializeField] private Sprite ClothesSprite;
    [SerializeField] private Sprite ClothesEquipSprite;
    [SerializeField] private string ClothesType;
    private GameObject Player;
    void Start()
    {
        ButtonImage = GetComponent<Image>();
        Equip = true;
    }

    public void FindPlayer()
    {
        if (Equip)
        {
            ButtonImage.sprite = ClothesSprite;
            Equip = false;
        }
        else
        {
            ButtonImage.sprite = ClothesEquipSprite;
            Equip = true;
        }
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PhotonView>().RPC("EquipClothes", RpcTarget.All, ClothesType, Equip);
    }
}
