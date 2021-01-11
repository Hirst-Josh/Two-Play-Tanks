using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMaster : MonoBehaviour
{
    public int scoreteam1;
    public int scoreteam2;
   
    private void Start()
    {
        scoreteam1 = 0;
        scoreteam2 = 0;

    }

    public void Team1score()
    {
        scoreteam1 += 5;
    }
    public void Team2score()
    {
        scoreteam2 += 5;
    }

}
