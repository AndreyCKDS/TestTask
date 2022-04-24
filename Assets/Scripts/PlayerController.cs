using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody Rig;
    private PhotonView PhotonView;
    private FixedJoystick Joystick;
    [SerializeField] private float Speed;
    private Vector3 Velocity;

    void Start()
    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsWalking", false);
        Rig = GetComponent<Rigidbody>();
        PhotonView = GetComponent<PhotonView>();
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
        }
        
    }
}
