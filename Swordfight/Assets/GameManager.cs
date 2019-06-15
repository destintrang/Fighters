using Photon.Pun;
using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPun, IPunObservable
{

    public Fighter p1;
    public Fighter p2;
    public int players = 0;
    Fighter winner = null;
    Fighter loser = null;

    public GameObject[] spaces;

    public enum Move { NONE, STRIKE, HEAVY, CRIPPLE, BLOCK, GRAB, SHOVE, COUNTER, LEAP }
    Move p1Move = Move.NONE;
    Move p2Move = Move.NONE;

    PhotonView PV;

    public Text infoText;


    public static GameManager instance;
    private void Awake()
    {
        //PhotonNetwork.OfflineMode = true;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartNewRound();
        PhotonView pv = GetComponent<PhotonView>();
        if (PV) PV.ObservedComponents.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Move != Move.NONE && p2Move != Move.NONE)
        {
            ExecuteTurn();
        }
    }


    void ExecuteTurn()
    {
        print("p1 move: " + p1Move + "; p2 move: " + p2Move);
        Combat();
        ResetNeutral();
        p1Move = Move.NONE;
        p2Move = Move.NONE;
    }


    void Combat ()
    {
        if (p1Move == Move.STRIKE)
        {
            if (p2Move == Move.HEAVY)
            {

            }
            else if (p2Move == Move.CRIPPLE)
            {

            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.GRAB || p2Move == Move.SHOVE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p2, 1);
                p2.Weaken();
            }
        }
        else if (p1Move == Move.HEAVY)
        {
            if (p2Move == Move.HEAVY)
            {

            }
            else if (p2Move == Move.CRIPPLE)
            {

            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p1, -2);
            }
            else if (p2Move == Move.GRAB || p2Move == Move.SHOVE)
            {
                MovePlayer(p2, 2);
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p1, -2);
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p2, 2);
                p2.Weaken();
            }
        }
        else if (p1Move == Move.CRIPPLE)
        {
            if (p2Move == Move.HEAVY)
            {

            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.GRAB || p2Move == Move.SHOVE)
            {
                p2.Weaken();
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.LEAP)
            {
                p2.Weaken();
                p2.Weaken();
            }
        }
        else if (p1Move == Move.BLOCK)
        {
            if (p2Move == Move.STRIKE  || p2Move == Move.CRIPPLE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.HEAVY)
            {
                MovePlayer(p2, 2);
            }
            else if (p2Move == Move.GRAB)
            {
                p1.Weaken();
            }
            else if (p2Move == Move.SHOVE)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p2, 1);
                p2.Weaken();
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p1, -1);
            }
        }
        else if (p1Move == Move.GRAB)
        {
            if (p2Move == Move.STRIKE)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.HEAVY)
            {
                MovePlayer(p1, -2);
            }
            else if (p2Move == Move.CRIPPLE)
            {
                p1.Weaken();
            }
            else if (p2Move == Move.BLOCK)
            {
                p2.Weaken();
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p1, -1);
            }
        }
        else if (p1Move == Move.SHOVE)
        {
            if (p2Move == Move.STRIKE)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.HEAVY)
            {
                MovePlayer(p1, -2);
            }
            else if (p2Move == Move.CRIPPLE)
            {
                p1.Weaken();
            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p1, -1);
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p1, -1);
            }
        }
        else if (p1Move == Move.COUNTER)
        {
            if (p2Move == Move.STRIKE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.HEAVY)
            {
                MovePlayer(p2, 2);
            }
            else if (p2Move == Move.CRIPPLE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p1, -1);
                p1.Weaken();
            }
            else if (p2Move == Move.GRAB)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.SHOVE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.COUNTER)
            {
                
            }
            else if (p2Move == Move.LEAP)
            {
                MovePlayer(p1, -1);
                p1.Weaken();
            }
        }
        else if (p1Move == Move.LEAP)
        {
            if (p2Move == Move.STRIKE)
            {
                MovePlayer(p1, -1);
                p1.Weaken();
            }
            else if (p2Move == Move.HEAVY)
            {
                MovePlayer(p1, -2);
                p1.Weaken();
            }
            else if (p2Move == Move.CRIPPLE)
            {
                p1.Weaken();
                p1.Weaken();
            }
            else if (p2Move == Move.BLOCK)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.GRAB)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.SHOVE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.COUNTER)
            {
                MovePlayer(p2, 1);
                p2.Weaken();
            }
            else if (p2Move == Move.LEAP)
            {
            }
        }

        string s = "";
        s += "Player 1: " + p1Move + "! Player 2: " + p2Move + "\n";
        if (winner)
        {
            s += winner.gameObject.name + " prevails!";
        }
        else
        {
            s += "Stalemate!";
        }
        UpdateInfo(s);
    }


    Fighter CheckOutofBounds ()
    {
        if (p1 != null && p1.pos < 0)
        {
            //GameOver();
            return p1;
        }
        else if (p2 != null && p2.pos > 5)
        {
            //GameOver();
            return p2;
        }

        return null;
    }


    void GameOver ()
    {
        if (p1.pos < 0)
        {
            // p2 won
            print("P2 won");
            ScoreManager.instance.IncrementScore(2);
        }
        if (p2.pos > 5)
        {
            // p1 won
            print("P1 won");
            ScoreManager.instance.IncrementScore(1);
        }
        StartNewRound();
    }

    public void StartNewRound ()
    {
        MoveTo(p1, 2);
        MoveTo(p2, 3);
    }


    public void StartPlayer (GameObject p)
    {
        if (!p1)
        {
            p1 = p.GetComponent<Fighter>();
            MoveTo(p1, 2);
            //this.photonView.RPC("UpdatePlayerNum", RpcTarget.All);
            
        }
        else if (!p2)
        {
            p2 = p.GetComponent<Fighter>();
            MoveTo(p2, 3);
            //this.photonView.RPC("UpdatePlayerNum", RpcTarget.All);
        }
    }

    


    void MovePlayer (Fighter p, int space)
    {
        loser = p;
        if (loser == p1) { winner = p2; }
        else { winner = p1; }
        p.pos += space;
        if (CheckOutofBounds()) { GameOver(); }
        else { p.transform.position = spaces[p.pos].transform.position; }
    }
    void MoveTo (Fighter p, int space)
    {
        p.pos = space;
        if (CheckOutofBounds()) {  }
        p.transform.position = spaces[space].transform.position;
    }

    void ResetNeutral ()
    {
        if (loser == p1)
        {
            MoveTo (p2, p1.pos + 1);
        }
        else if (loser == p2)
        {
            MoveTo(p1, p2.pos - 1);
        }

        loser = null;
    }

    public void Strike(int player)
    {
        if (player == 1)
        {
            //p1Move = Move.STRIKE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.STRIKE);
        }
        else if (player == 2)
        {
            //p2Move = Move.STRIKE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.STRIKE);
        }
    }
    public void Heavy(int player)
    {
        if (player == 1)
        {
            //p1Move = Move.HEAVY;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.HEAVY);
        }
        else if (player == 2) {
            //p2Move = Move.HEAVY;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.HEAVY);
        }
    }
    public void Cripple(int player)
    {
        if (player == 1) {
            //p1Move = Move.CRIPPLE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.CRIPPLE);
        }
        else if (player == 2) {
            //p2Move = Move.CRIPPLE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.CRIPPLE);
        }
    }
    public void Block(int player)
    {
        if (player == 1) {
            //p1Move = Move.BLOCK;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.BLOCK);
        }
        else if (player == 2) {
            //p2Move = Move.BLOCK;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.BLOCK);
        }
    }
    public void Grab(int player)
    {
        if (player == 1) {
            //p1Move = Move.GRAB;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.GRAB);
        }
        else if (player == 2) {
            //p2Move = Move.GRAB;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.GRAB);
        }
    }
    public void Shove(int player)
    {
        if (player == 1)
        {
            //p1Move = Move.SHOVE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.SHOVE);
        }
        else if (player == 2)
        {
            //p2Move = Move.SHOVE;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.SHOVE);
        }
    }
    public void Counter(int player)
    {
        if (player == 1)
        {
            //p1Move = Move.COUNTER;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.COUNTER);
        }
        else if (player == 2)
        {
            //p2Move = Move.COUNTER;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.COUNTER);
        }
    }
    public void Leap(int player)
    {
        if (player == 1)
        {
            //p1Move = Move.LEAP;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 1, Move.LEAP);
        }
        else if (player == 2)
        {
            //p2Move = Move.LEAP;
            GetComponent<PhotonView>().RPC("UpdateMove", RpcTarget.All, 2, Move.LEAP);
        }
    }
    [PunRPC]
    void UpdateMove (int p, GameManager.Move m)
    {
        if (p == 1)
        {
            p1Move = m;
        }
        else if (p == 2)
        {
            p2Move = m;
        }
    }


    void UpdateInfo (string s)
    {
        infoText.text = s;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            return;
        }
        else
        {

            return;
        }
    }
}
