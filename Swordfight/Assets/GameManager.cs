using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Fighter p1;
    public Fighter p2;
    Fighter loser = null;

    public GameObject[] spaces;

    public enum Move { NONE, STRIKE, HEAVY, CRIPPLE, BLOCK, GRAB, SHOVE, COUNTER, LEAP }
    Move p1Move = Move.NONE;
    Move p2Move = Move.NONE;


    // Start is called before the first frame update
    void Start()
    {
        StartNewRound();
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
            if (p2Move == Move.STRIKE || p2Move == Move.HEAVY || p2Move == Move.CRIPPLE)
            {
                MovePlayer(p2, 1);
            }
            else if (p2Move == Move.CRIPPLE)
            {

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
                MovePlayer(p2, -1);
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
    }


    Fighter CheckOutofBounds ()
    {
        if (p1.pos < 0)
        {
            //GameOver();
            return p1;
        }
        else if (p2.pos > 5)
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

    void StartNewRound ()
    {
        MoveTo(p1, 2);
        MoveTo(p2, 3);
    }

    void MovePlayer (Fighter p, int space)
    {
        loser = p; 
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
        if (player == 1) { p1Move = Move.STRIKE; }
        else if (player == 2) { p2Move = Move.STRIKE; }
    }
    public void Heavy(int player)
    {
        if (player == 1) { p1Move = Move.HEAVY; }
        else if (player == 2) { p2Move = Move.HEAVY; }
    }
    public void Cripple(int player)
    {
        if (player == 1) { p1Move = Move.CRIPPLE; }
        else if (player == 2) { p2Move = Move.CRIPPLE; }
    }
    public void Block(int player)
    {
        if (player == 1) { p1Move = Move.BLOCK; }
        else if (player == 2) { p2Move = Move.BLOCK; }
    }
    public void Grab(int player)
    {
        if (player == 1) { p1Move = Move.GRAB; }
        else if (player == 2) { p2Move = Move.GRAB; }
    }
    public void Shove(int player)
    {
        if (player == 1) { p1Move = Move.SHOVE; }
        else if (player == 2) { p2Move = Move.SHOVE; }
    }
    public void Counter(int player)
    {
        if (player == 1) { p1Move = Move.COUNTER; }
        else if (player == 2) { p2Move = Move.COUNTER; }
    }
    public void Leap(int player)
    {
        if (player == 1) { p1Move = Move.LEAP; }
        else if (player == 2) { p2Move = Move.LEAP; }
    }
}
