using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks, IPunObservable
{

    int players = 0;

    // This script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
    }
    private void CreatePlayer()
    {
        /*
        if (players == 0)
        {
            print(players);
            Debug.Log("Creating Player 1");
            GameObject p = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerOne"), Vector3.zero, Quaternion.identity);
            GameManager.instance.StartPlayer(p);
            this.photonView.RPC("UpdatePlayerNum", RpcTarget.All);
        }
        else if (players == 1)
        {
            print(players);
            Debug.Log("Creating Player 2");
            GameObject p = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerTwo"), Vector3.zero, Quaternion.identity);
            GameManager.instance.StartPlayer(p);
            this.photonView.RPC("UpdatePlayerNum", RpcTarget.All);
        }
        */
        Debug.Log("Creating Player 1");
        GameObject p = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), Vector3.zero, Quaternion.identity);
    }


    [PunRPC]
    void UpdatePlayerNum()
    {
        players++;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(players);
            //stream.SendNext(position);
            Debug.Log("I am the local client" + GetComponent<PhotonView>().ViewID);

        }
        else
        {

            players = (int)stream.ReceiveNext();
            //position = (Vector3)stream.ReceiveNext();
            Debug.Log("I am the Remote client" + GetComponent<PhotonView>().ViewID);
        }
    }
}