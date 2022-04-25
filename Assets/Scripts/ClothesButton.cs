using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ClothesButton : MonoBehaviourPun
{
    private Image ButtonImage;
    private bool Equip;
    [SerializeField] private Sprite ClothesSprite;
    [SerializeField] private Sprite ClothesEquipSprite;
    [SerializeField] private string ClothesType;
    private PhotonView PhotonView;
    private GameObject Player;
    void Start()
    {
        PhotonView = GetComponent<PhotonView>();
        ButtonImage = GetComponent<Image>();
        Equip = true;
    }

    public void FindPlayer()
    {
        if (Equip)
        {
            ButtonImage.sprite = ClothesSprite;
            Equip = false;
            Player = GameObject.FindWithTag("Player");
            PhotonView.RPC("EquipClothes", RpcTarget.All, ClothesType);
        }
        else
        {
            ButtonImage.sprite = ClothesEquipSprite;
            Equip = true;
            Player = GameObject.FindWithTag("Player");
            PhotonView.RPC("EquipClothes", RpcTarget.All, ClothesType);
        }
    }

    [PunRPC]
    void EquipClothes(string ClothesType)
    {
        if (Equip)
        {
            GameObject Clothes = Player.transform.Find(ClothesType).gameObject;
            Clothes.SetActive(true);
            GameObject NackedClothes = Player.transform.Find("Nacked" + ClothesType).gameObject;
            NackedClothes.SetActive(false);
        }
        else
        {
            GameObject Clothes = Player.transform.Find(ClothesType).gameObject;
            Clothes.SetActive(false);
            GameObject NackedClothes = Player.transform.Find("Nacked" + ClothesType).gameObject;
            NackedClothes.SetActive(true);
        }
    }
}
