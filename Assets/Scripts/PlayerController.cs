using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private Animator Anim;
    private Rigidbody Rig;
    private PhotonView PhotonView;
    private FixedJoystick Joystick;
    [SerializeField] private float Speed;
    private Vector3 Velocity;
    private Quaternion InitialRotation;
    [SerializeField] private TMP_Text NicknameText;

    void Start()
    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsWalking", false);
        Rig = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(3, 3);
        PhotonView = GetComponent<PhotonView>();

        NicknameText.text = PhotonView.Owner.NickName;
        InitialRotation = Camera.main.transform.rotation;
    }

    private void FixedUpdate()
    {
        Velocity = new Vector3(Joystick.Horizontal * Speed, Rig.velocity.y, Joystick.Vertical * Speed);
        if (PhotonView.IsMine)
        {
            Rig.velocity = Velocity;
            if (Joystick.Horizontal != 0 || Joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(Rig.velocity);
                Anim.SetBool("IsWalking", true);
            }
            else
                Anim.SetBool("IsWalking", false);
            PhotonView.RPC("NicknameRotation", RpcTarget.All);
        }
    }

    [PunRPC]
    public void EquipClothes(string ClothesType, bool Equip)
    {
        if (Equip)
        {
            GameObject Clothes = transform.Find(ClothesType).gameObject;
            Clothes.SetActive(true);
            GameObject NackedClothes = transform.Find("Nacked" + ClothesType).gameObject;
            NackedClothes.SetActive(false);
        }
        else
        {
            GameObject Clothes = transform.Find(ClothesType).gameObject;
            Clothes.SetActive(false);
            GameObject NackedClothes = transform.Find("Nacked" + ClothesType).gameObject;
            NackedClothes.SetActive(true);
        }
    }

    [PunRPC]
    public void NicknameRotation()
    {
        NicknameText.transform.rotation = InitialRotation;
    }
}
