using Photon.Pun;
using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour, IPunObservable
{

    public int pos;
    public OptionManager o;

    
    public void Weaken ()
    {
        o.Weaken();
    }

    public bool CanFight ()
    {
        return o.CanFight();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(pos);
            //stream.SendNext(position);

        }
        else
        {

            pos = (int)stream.ReceiveNext();
            //position = (Vector3)stream.ReceiveNext();
        }
    }
}
