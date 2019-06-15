using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    List<GameManager.Move> available = new List<GameManager.Move>{ GameManager.Move.STRIKE, GameManager.Move.HEAVY, GameManager.Move.CRIPPLE,
                                    GameManager.Move.BLOCK, GameManager.Move.GRAB, GameManager.Move.SHOVE,
                                    GameManager.Move.COUNTER, GameManager.Move.LEAP, };

    public GameObject strikeButton;
    public GameObject heavyButton;
    public GameObject crippleButton;
    public GameObject blockButton;
    public GameObject grabButton;
    public GameObject shoveButton;
    public GameObject counterButton;
    public GameObject leapButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableOption (GameManager.Move m)
    {
        switch (m)
        {
            case GameManager.Move.STRIKE:
                strikeButton.SetActive(false);
                break;
            case GameManager.Move.HEAVY:
                heavyButton.SetActive(false);
                break;
            case GameManager.Move.CRIPPLE:
                crippleButton.SetActive(false);
                break;
            case GameManager.Move.BLOCK:
                blockButton.SetActive(false);
                break;
            case GameManager.Move.GRAB:
                grabButton.SetActive(false);
                break;
            case GameManager.Move.SHOVE:
                shoveButton.SetActive(false);
                break;
            case GameManager.Move.COUNTER:
                counterButton.SetActive(false);
                break;
            case GameManager.Move.LEAP:
                leapButton.SetActive(false);
                break;
        }
    }

    public void Weaken ()
    {
        GameManager.Move r = available[Random.Range(0, available.Count)];
        DisableOption(r);
        available.Remove(r);
    }


    public void ResetOptions ()
    {
        strikeButton.SetActive(true);
        heavyButton.SetActive(true);
        crippleButton.SetActive(true);
        blockButton.SetActive(true);
        grabButton.SetActive(true);
        shoveButton.SetActive(true);
        counterButton.SetActive(true);
        leapButton.SetActive(true);
    }


    public bool CanFight()
    {
        if (available.Count == 0) { return false; }
        return true;
    }
}
