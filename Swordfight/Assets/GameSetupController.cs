using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks, IPunObservable
{

    int players;

    public GameObject pOne;
    public GameObject pTwo;

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
        this.photonView.RPC("UpdatePlayerNum", RpcTarget.All);
        Debug.Log("Creating Player " + PhotonNetwork.CountOfPlayers);
        if (PhotonNetwork.CountOfPlayers != 2)
        {
            print("showing p1 options");
            pOne.SetActive(true);
        }
        else if (PhotonNetwork.CountOfPlayers != 1)
        {
            print("showing p2 options");
            pTwo.SetActive(true);
        }
        GameObject p = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), Vector3.zero, Quaternion.identity);
    }


    [PunRPC]
    void UpdatePlayerNum()
    {
        if (players == null)
        {
            players = 0;
        }
        players++;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(players);
        }
        else
        {

            players = (int)stream.ReceiveNext();
        }
    }
}