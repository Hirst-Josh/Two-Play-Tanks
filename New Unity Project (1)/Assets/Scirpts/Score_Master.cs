using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Master : MonoBehaviour
{
    public Text Tankskilled;
    public Text Tankslosted;
    public Text flagsgot;
    public Text flaglosted;
    int empty;
    public int killed;
    public int losted;
    public int flagsg;
    public int flagslosted;
    void Start()
    {
        empty = 0;
        Tankskilled.text = empty.ToString();
        Tankslosted.text = empty.ToString();
        flaglosted.text = empty.ToString();
        flagsgot.text = empty.ToString();
    }

    public void newscore()
    {
        Tankskilled.text = killed.ToString();
        Tankslosted.text = losted.ToString();
        flaglosted.text = flagslosted.ToString();
        flagsgot.text = flagsg.ToString();
    }

   
}
