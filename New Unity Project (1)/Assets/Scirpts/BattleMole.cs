using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMole : MonoBehaviour
{
   public Vector3 Team1TargetTracker1;
   private float Team1Target1Timer;
   public bool isT1T1;
   public Vector3 Team1TargetTracker2;
   private float Team1Target2Timer;
    public bool isT1T2;
   public Vector3 Team1TargetTracker3;
   private float Team1Target3Timer;
    public bool isT1T3;
   public Vector3 Team1TargetTracker4;
   private float Team1Target4Timer;
    public bool isT1T4;
   public Vector3 Team1TargetTracker5;
   private float Team1Target5Timer;
    public bool isT1T5;
   public Vector3 Team2TargetTracker1;
   private float Team2Target1Timer;
    public bool isT2T1;
   public Vector3 Team2TargetTracker2;
   private float Team2Target2Timer;
    public bool isT2T2;
   public Vector3 Team2TargetTracker3;
   private float Team2Target3Timer;
    public bool isT2T3;
   public Vector3 Team2TargetTracker4;
   private float Team2Target4Timer;
    public bool isT2T4;
   public Vector3 Team2TargetTracker5;
   private float Team2Target5Timer;
    public bool isT2T5;
   public Vector3 Team1Contract;
   public Vector3 Team2Contract;


    public GameObject Team1closet1;
    public GameObject Team1closet2;
    public GameObject Team1closet3;
    public GameObject Team2closet1;
    public GameObject Team2closet2;
    public GameObject Team2closet3;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("Checker", 0.0f, 1.0f);
    }

    // Update is called once per frame
   
    void Checker()
    {
        if (isT1T1 == true)
        {
            if(Team1Target1Timer < 60.0f)
            {
                Team1Target1Timer += 1.0f;
            }
            else
            {
                isT1T1 = false;
                Team1Target1Timer = 0.0f;
            }
        }
        if (isT1T2 == true)
        {
            if (Team1Target2Timer < 60.0f)
            {
                Team1Target2Timer += 1.0f;
            }
            else
            {
                isT1T2 = false;
                Team1Target2Timer = 0.0f;
            }
        }
        if (isT1T3 == true)
        {
            if (Team1Target3Timer < 60.0f)
            {
                Team1Target3Timer += 1.0f;
            }
            else
            {
                isT1T3 = false;
                Team1Target3Timer = 0.0f;
            }
        }
        if (isT1T4 == true)
        {
            if (Team1Target4Timer < 60.0f)
            {
                Team1Target4Timer += 1.0f;
            }
            else
            {
                isT1T4 = false;
                Team1Target4Timer = 0.0f;
            }
        }
        if (isT1T5 == true)
        {
            if (Team1Target5Timer < 60.0f)
            {
                Team1Target5Timer += 1.0f;
            }
            else
            {
                isT1T5 = false;
                Team1Target5Timer = 0.0f;
            }
        }

        if (isT2T1 == true)
        {
            if (Team2Target1Timer < 60.0f)
            {
                Team2Target1Timer += 1.0f;
            }
            else
            {
                isT2T1 = false;
                Team2Target1Timer = 0.0f;
            }
        }
        if (isT2T2 == true)
        {
            if (Team2Target2Timer < 60.0f)
            {
                Team2Target2Timer += 1.0f;
            }
            else
            {
                isT2T2 = false;
                Team2Target2Timer = 0.0f;
            }
        }
        if (isT2T3 == true)
        {
            if (Team2Target3Timer < 60.0f)
            {
                Team2Target3Timer += 1.0f;
            }
            else
            {
                isT2T3 = false;
                Team2Target3Timer = 0.0f;
            }
        }
        if (isT2T4 == true)
        {
            if (Team2Target4Timer < 60.0f)
            {
                Team2Target4Timer += 1.0f;
            }
            else
            {
                isT2T4 = false;
                Team2Target4Timer = 0.0f;
            }
        }
        if (isT2T5 == true)
        {
            if (Team2Target5Timer < 60.0f)
            {
                Team2Target5Timer += 1.0f;
            }
            else
            {
                isT2T5 = false;
                Team2Target5Timer = 0.0f;
            }
        }
    }

    public void ToMoleTeam1()
    {


        if (isT1T1 == false)
        {
            Team1TargetTracker1 = Team1Contract;
            isT1T1 = true;
            FindCloseistTeam1(Team1TargetTracker1);
        } 
        else if (isT1T2 == false)
        {
            Team1TargetTracker2 = Team1Contract;
            isT1T2 = true;
            FindCloseistTeam1(Team1TargetTracker2);
        }
        else if (isT1T3 == false)
        {
            Team1TargetTracker3 = Team1Contract;
            isT1T3 = true;
            FindCloseistTeam1(Team1TargetTracker3);
        }
        else if (isT1T4 == false)
        {
            Team1TargetTracker4 = Team1Contract;
            isT1T4 = true;
            FindCloseistTeam1(Team1TargetTracker4);
        }
        else if (isT1T5 == false)
        {
            Team1TargetTracker5 = Team1Contract;
            isT1T5 = true;
            FindCloseistTeam1(Team1TargetTracker5);
        }
    }


    public void ToMoleTeam2()
    {
        if (isT2T1 == false)
        {
            Team2TargetTracker1 = Team2Contract;
            isT2T1 = true;
        }
        else if (isT2T2 == false)
        {
            Team2TargetTracker2 = Team2Contract;
            isT2T2 = true;
        }
        else if (isT2T3 == false)
        {
            Team2TargetTracker3 = Team2Contract;
            isT2T3 = true;
        }
        else if (isT2T4 == false)
        {
            Team2TargetTracker4 = Team2Contract;
            isT2T4 = true;
        }
        else if (isT2T5 == false)
        {
            Team2TargetTracker5 = Team2Contract;
            isT2T5 = true;
        }
    }

    public void FindCloseistTeam1(Vector3 Contract)
    {
        Tankfsm tankfsm1 = Team1closet1.GetComponent<Tankfsm>();
        tankfsm1.BmoleTargetLastPostion = Contract;
        tankfsm1.BattleMoleTrue();
        Tankfsm tankfsm2 = Team1closet2.GetComponent<Tankfsm>();
        tankfsm2.BmoleTargetLastPostion = Contract;
        tankfsm2.BattleMoleTrue();
        Tankfsm tankfsm3 = Team1closet3.GetComponent<Tankfsm>();
        tankfsm3.BmoleTargetLastPostion = Contract;
        tankfsm3.BattleMoleTrue();
    }
    public  void FindCloseistTeam2(Vector3 Contract)
     {
        Tankfsm tankfsm1 = Team2closet1.GetComponent<Tankfsm>();
        tankfsm1.BmoleTargetLastPostion = Contract;
        tankfsm1.BattleMoleTrue();
        Tankfsm tankfsm2 = Team2closet2.GetComponent<Tankfsm>();
        tankfsm2.BmoleTargetLastPostion = Contract;
        tankfsm2.BattleMoleTrue();
        Tankfsm tankfsm3 = Team2closet3.GetComponent<Tankfsm>();
        tankfsm3.BmoleTargetLastPostion = Contract;
        tankfsm3.BattleMoleTrue();
    }
}
