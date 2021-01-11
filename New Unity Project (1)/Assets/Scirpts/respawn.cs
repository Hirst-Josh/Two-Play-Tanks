using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tank;
    public GameObject t34;
    public GameObject m4;
    public GameObject T72;
    public GameObject missletank;
    public GameObject smk;
    public GameObject EnemyFlagZone;
    public GameObject FlagZone;
    public GameObject flag;
    public bool GamemodeFlag;
    public bool GamemodeZone;
    public GameObject ZoneA;
    public GameObject ZoneB;
    public int ism4;
    public int ist34;
    public int issmk;
    public int ist72;
    public int ismissletank;
    public int deathmacth;
    public int capture;
    public string team;
    public float Timer = 1;
    GameObject spawn;
    GameObject remove;
    int choose;
    int number;
    public bool checker;
    public GameObject flagui;
    public GameObject deathmatchui;
    public GameObject[] waypoints;
    public GameObject[] waypoints2;
    public GameObject[] waypoints3;

    public void Start()
    {
        number = 1;

        
        Invoke("kill", 0.1f);
        InvokeRepeating("spawnt", 0.5f, 2.0f);
    }

    private void Awake()
    {
     
        
    }

    void kill()
    {

        ist34 = PlayerPrefs.GetInt("T34");
        ism4 = PlayerPrefs.GetInt("M4");
        ist72 =PlayerPrefs.GetInt("T72");
        issmk = PlayerPrefs.GetInt("SMK");
        ismissletank = PlayerPrefs.GetInt("Missle");
        deathmacth = PlayerPrefs.GetInt("deathmacth");
        capture = PlayerPrefs.GetInt("capture");

        if (capture == 1 && checker == true)
        {
            flag.SetActive(true);
            EnemyFlagZone.SetActive(true);
            FlagZone.SetActive(true);
            GamemodeFlag = true;
            flagui.SetActive(true);
            deathmatchui.SetActive(false);
        }
        else if (checker == true)
        {
            flag.SetActive(false);
            EnemyFlagZone.SetActive(false);
            FlagZone.SetActive(false);
            GamemodeFlag = false;
            flagui.SetActive(false);
            deathmatchui.SetActive(true);
        }
        else if(capture == 1)
        {
            GamemodeFlag = true;
        }
    }
    void spawnt()
    {

        if (GameObject.FindGameObjectsWithTag(team).Length < 9)

        {
            //int num = 20;
            int num = Random.Range(1, 100);

            if (num >= 15)
            {  
                choose = Random.Range(1, 3);
               // Debug.Log(choose);

                if (GamemodeFlag == false  && GamemodeZone == false)
                {
                   
                    if(choose == 1)
                    {
                        if (ism4 == 1)
                        {
                            spawn = Instantiate(m4, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                    if (choose == 2)
                    {
                        if (ist34 == 1)
                        {
                            spawn = Instantiate(t34, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            number += 1;
                            
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                    
                }
                else if(GamemodeZone == true)
                {
                    if (choose == 1)
                    {
                        if (ism4 == 1)
                        {

                            spawn = Instantiate(m4, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().ZoneA = ZoneA;
                            spawn.GetComponent<Tankfsm>().ZoneB = ZoneB;
                            spawn.GetComponent<Tankfsm>().ZoneSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }

                    }
                    if (choose == 2)
                    {
                        if (ist34 == 1)
                        {

                            spawn = Instantiate(t34, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().ZoneA = ZoneA;
                            spawn.GetComponent<Tankfsm>().ZoneB = ZoneB;
                            spawn.GetComponent<Tankfsm>().ZoneSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                }
                else if (GamemodeFlag == true)
                {
                    if (choose == 1)
                    {
                        if (ism4 == 1)
                        {

                            spawn = Instantiate(m4, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().Flag = flag;
                            spawn.GetComponent<Tankfsm>().FlagZone = FlagZone;
                            spawn.GetComponent<Tankfsm>().EnemyFlagZone = EnemyFlagZone;
                            spawn.GetComponent<Tankfsm>().FlagSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }

                    if (choose == 2)
                    {
                        if (ist34 == 1)
                        {

                            spawn = Instantiate(t34, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().Flag = flag;
                            spawn.GetComponent<Tankfsm>().FlagZone = FlagZone;
                            spawn.GetComponent<Tankfsm>().EnemyFlagZone = EnemyFlagZone;
                            spawn.GetComponent<Tankfsm>().FlagSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                }
                
            }

            if (num >= 6 && num <= 14)
            {
                choose = Random.Range(1, 3);
              //  Debug.Log(choose);

                if (GamemodeFlag == false && GamemodeZone == false)
                {
                    if(choose == 1)
                    {
                        if (ist72 == 1)
                        {
                            spawn = Instantiate(T72, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                    if (choose == 2)
                    {
                        if(ismissletank == 1)
                        {
                            spawn = Instantiate(missletank, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }     
                }
                else if (GamemodeZone == true)
                {
                    if (choose == 1)
                    {
                        if(ist72 == 1)
                        {
                            spawn = Instantiate(T72, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().ZoneA = ZoneA;
                            spawn.GetComponent<Tankfsm>().ZoneB = ZoneB;
                            spawn.GetComponent<Tankfsm>().ZoneSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                    if (choose == 2)
                    {
                        if (ismissletank == 1)
                        {
                            spawn = Instantiate(missletank, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            spawn.GetComponent<Tankfsm>().ZoneA = ZoneA;
                            spawn.GetComponent<Tankfsm>().ZoneB = ZoneB;
                            spawn.GetComponent<Tankfsm>().ZoneSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                }
                else
                {
                    
                    if (choose == 1)
                    {
                        if (ist72 == 1)
                        {
                            spawn = Instantiate(T72, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            Tankfsm setup = spawn.GetComponent<Tankfsm>();
                            setup.Flag = flag;
                            setup.FlagZone = FlagZone;
                            setup.EnemyFlagZone = EnemyFlagZone;
                            setup.FlagSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                    if (choose == 2)
                    {
                        if (ismissletank == 1)
                        {
                            spawn = Instantiate(missletank, transform.position, Quaternion.identity) as GameObject;
                            spawn.gameObject.name = spawn.gameObject.name + number;
                            Tankfsm setup = spawn.GetComponent<Tankfsm>();
                            setup.Flag = flag;
                            setup.FlagZone = FlagZone;
                            setup.EnemyFlagZone = EnemyFlagZone;
                            setup.FlagSetUp();
                            number += 1;
                        }
                        else
                        {
                            spawnt();
                        }
                    }
                }
            }
            if (num <= 5)
            {
                if(GamemodeFlag == false && GamemodeZone == false)
                {
                    if (issmk == 1)
                    {
                        spawn = Instantiate(smk, transform.position, Quaternion.identity) as GameObject;
                        spawn.gameObject.name = spawn.gameObject.name + number;
                        number += 1;
                    }
                    else
                    {
                        spawnt();
                    }
                }
                else if (GamemodeZone == true)
                {
                    if (issmk == 1)
                    {
                        spawn = Instantiate(smk, transform.position, Quaternion.identity) as GameObject;
                        spawn.gameObject.name = spawn.gameObject.name + number;
                        spawn.GetComponent<Tankfsm>().ZoneA = ZoneA;
                        spawn.GetComponent<Tankfsm>().ZoneB = ZoneB;
                        spawn.GetComponent<Tankfsm>().ZoneSetUp();
                        number += 1;
                    }
                    else
                    {
                        spawnt();
                    }
                }
                else
                {
                    if (issmk == 1)
                    {
                        spawn = Instantiate(smk, transform.position, Quaternion.identity) as GameObject;
                        spawn.gameObject.name = spawn.gameObject.name + number;
                        Tankfsm setup = spawn.GetComponent<Tankfsm>();
                        setup.Flag = flag;
                        setup.FlagZone = FlagZone;
                        setup.EnemyFlagZone = EnemyFlagZone;
                        setup.FlagSetUp();
                        number += 1;
                    }
                    else
                    {
                        spawnt();
                    }
                }
            }
        }
    }
}


       
    

   
