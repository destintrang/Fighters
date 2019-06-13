using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
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
}
