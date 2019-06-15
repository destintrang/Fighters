using Photon.Pun;
using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour, IPunObservable
{

    int p1Score = 0;
    int p2Score = 0;

    public Color red;
    public Color blue;

    public List<Image> pOnePoints;
    public List<Image> pTwoPoints;

    public GameObject endCanvas;
    public Text endText;


    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore (int i)
    {
        if (i == 1)
        {
            p1Score++;
            pOnePoints[p1Score - 1].color = red;
            if (p1Score == 2)
            {
                End("P1 wins!");
            }
        }
        else if (i == 2)
        {
            p2Score++;
            pTwoPoints[p2Score - 1].color = blue;
            if (p2Score == 2)
            {
                End("P2 wins!");
            }
        }
    }

    void End (string txt)
    {
        Time.timeScale = 0;
        endCanvas.SetActive(true);
        endText.text = txt;
    }

    public void RestartGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        p1Score = 0;
        p2Score = 0;
        foreach (OptionManager o in FindObjectsOfType<OptionManager>())
        {
            o.ResetOptions();
        }
        Time.timeScale = 1;
        endCanvas.SetActive(false);
        GameManager.instance.StartNewRound();

        foreach (Image i in pOnePoints)
        {
            i.color = Color.white;
        }
        foreach (Image i in pTwoPoints)
        {
            i.color = Color.white;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(p1Score);
            stream.SendNext(p2Score);
            stream.SendNext(pOnePoints);
            stream.SendNext(pTwoPoints);
        }
        else
        {

            p1Score = (int)stream.ReceiveNext();
            p2Score = (int)stream.ReceiveNext();

            pOnePoints = (List<Image>)stream.ReceiveNext();
            pTwoPoints = (List<Image>)stream.ReceiveNext();
        }
    }
}
