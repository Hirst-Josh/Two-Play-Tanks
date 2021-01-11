using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMaster : MonoBehaviour
{

    public bool FlagSysterm;
    public bool flagFree;
    public bool Team1HasFlag;
    public bool Team2HasFlag;
    public GameObject FlagCarier;
    public int Team1Score;
    public int Team2Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFlagToFree()
    {
        flagFree = true;
        Team1HasFlag = false;
        Team2HasFlag = false;
        FlagCarier = null;
    }
    public void SetFlagToTeam1()
    {
        Team1HasFlag = true;
        Team2HasFlag = false;
        flagFree = false;
    }
    public void SetFlagToTeam2()
    {
        Team2HasFlag = true;
        Team1HasFlag = false;
        flagFree = false;
    }
}
