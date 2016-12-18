using UnityEngine;
using System.Collections;

public class NetworkAnimation : MonoBehaviour {

    /*
    public Animator anim;
    public Pl_Values plValues;
    public PhotonView photonView;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(anim.GetBool("IsRunning"));
            stream.SendNext(anim.GetBool("IsGrounded"));
            stream.SendNext(anim.GetInteger("State"));
            stream.SendNext(anim.GetFloat("Speed"));
            stream.SendNext(anim.GetFloat("Horizontal"));
            stream.SendNext(anim.GetFloat("Vertical"));
        }
        else
        {
            //Network player, receive data
            plValues.running = (bool)stream.ReceiveNext();
            plValues.grounded = (bool)stream.ReceiveNext();
            plValues.state = (int)stream.ReceiveNext();
            plValues.speed = (float)stream.ReceiveNext();
            plValues.hor = (float)stream.ReceiveNext();
            plValues.ver = (float)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update () {
        if (!photonView.isMine)
        {
            anim.SetBool("IsRunning", plValues.running);
            anim.SetBool("IsGrounded", plValues.grounded);
            anim.SetInteger("State", plValues.state);
            anim.SetFloat("Speed", plValues.speed);
            anim.SetFloat("Horizontal", plValues.hor);
            anim.SetFloat("Vertical", plValues.ver);
        }
        else
        {
            anim.SetBool("IsRunning", plValues.running);
            anim.SetBool("IsGrounded", plValues.grounded);
            anim.SetInteger("State", plValues.state);
            anim.SetFloat("Speed", plValues.speed);
            anim.SetFloat("Horizontal", plValues.hor);
            anim.SetFloat("Vertical", plValues.ver);
        }
    }
    */
}
