using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

    public int exp;
    public int Lev{
        get{
            return exp / 750;
        }
    }
}
