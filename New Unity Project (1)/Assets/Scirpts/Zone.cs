using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public List<GameObject> listTeam1;
    public List<GameObject> listTeam2;
    private int listTeam1Size;
    private int listTeam2Size;
    int temp;
    bool takeover;
    int takeoveramount;
    int takeoveramount2;
    public ZoneMaster zoneMaster;


    private void Start()
    {
        temp = 0;
        takeover = false;
        takeoveramount = 0;
        takeoveramount2 = 0;
        InvokeRepeating("Takerover", 0.0f, 1.0f);
    }
    void Takerover()
    {
        listTeam1Size = listTeam1.Count;
        listTeam2Size = listTeam2.Count;

        if(listTeam1Size > 0 || listTeam2Size > 0)
        {
            if(listTeam1Size > listTeam2Size)
            {
                temp = listTeam1Size - listTeam2Size;
                if (temp >= 3)
                {
                    if (takeoveramount2 == 0)
                    {
                        takeoveramount += 3;
                    }
                    else
                    {
                        takeoveramount2 -= 3;
                        if(takeoveramount2 <= 0)
                        {
                            takeoveramount2 = 0;
                        }
                    }
                }
                else if (temp == 2)
                {
                    if (takeoveramount2 == 0)
                    {
                        takeoveramount += 2;
                    }
                    else
                    {
                        takeoveramount2 -= 2;
                        if (takeoveramount2 <= 0)
                        {
                            takeoveramount2 = 0;
                        }
                    }
                }
                else if (temp == 1)
                {
                    if (takeoveramount2 == 0)
                    {
                        takeoveramount += 1;
                    }
                    else
                    {
                        takeoveramount2 -= 1;
                        if (takeoveramount2 <= 0)
                        {
                            takeoveramount2 = 0;
                        }
                    }
                }
                else if (temp >= 3)
                {
                    if (takeoveramount2 == 0)
                    {
                        takeoveramount += 3;
                    }
                    else
                    {
                        takeoveramount2 -= 4;
                        if (takeoveramount2 <= 0)
                        {
                            takeoveramount2 = 0;
                        }
                    }
                }

                foreach(GameObject gameObject in listTeam1)
                {
                    if(gameObject.GetComponent<Tankfsm>()== true)
                    {
                        gameObject.GetComponent<Tankfsm>().ZonesPoint += 1;
                    }

                    if (gameObject.GetComponent<TankDrive>() == true)
                    {
                        gameObject.GetComponent<TankDrive>().ZonesPoint += 1;
                    }
                }
            }

            if (listTeam2Size > listTeam1Size)
            {
                temp = listTeam2Size - listTeam1Size;

                if (temp == 3)
                {
                    if (takeoveramount == 0)
                    {
                        takeoveramount2 += 3;
                    }
                    else
                    {
                        takeoveramount -= 3;
                        if (takeoveramount <= 0)
                        {
                            takeoveramount = 0;
                        }
                    }
                }
                else if (temp == 2)
                {
                    if (takeoveramount == 0)
                    {
                        takeoveramount2 += 2;
                    }
                    else
                    {
                        takeoveramount -= 2;
                        if (takeoveramount <= 0)
                        {
                            takeoveramount = 0;
                        }
                    }
                }
                else if (temp == 1)
                {
                    if (takeoveramount == 0)
                    {
                        takeoveramount2 += 1;
                    }
                    else
                    {
                        takeoveramount -= 1;
                        if (takeoveramount <= 0)
                        {
                            takeoveramount = 0;
                        }
                    }
                }
                else if (temp >= 3)
                {
                    if (takeoveramount == 0)
                    {
                        takeoveramount2 += 3;
                    }
                    else
                    {
                        takeoveramount -= 4;
                        if (takeoveramount <= 0)
                        {
                            takeoveramount = 0;
                        }
                    }
                }
            }

            if(takeoveramount >= 100)
            {
                zoneMaster.Team1score();
            }
            if (takeoveramount2 >= 100)
            {
                zoneMaster.Team2score();
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Team1Tracker>()== true)
        {
            listTeam1.Add(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Team2Tracker>() == true)
        {
            listTeam2.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Team1Tracker>() == true)
        {
            listTeam1.Remove(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Team2Tracker>() == true)
        {
            listTeam2.Remove(collision.gameObject);
        }
    }
}
