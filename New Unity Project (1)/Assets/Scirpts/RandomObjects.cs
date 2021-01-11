using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjects : MonoBehaviour
{
    public Terrain terrain;
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z
    public GameObject[] Health;
    public GameObject[] Rico;
    public GameObject[] rocket;
    public GameObject[] total;
    public GameObject[] RapidFire;
    public GameObject healthpp;
    public int isheath;
    public GameObject rapiedpp;
    public int israpied;
    public GameObject ricopp;
    public int isrico;
    public GameObject rocketpp;
    public int isrocket;
    public int isactive;

    void Start()
    {
        // terrain size x
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;
        Invoke("get", 0.1f);
        InvokeRepeating("Checker", 1.0f, 1.0f);

    }

    private void get()
    {

        isactive = PlayerPrefs.GetInt("Powerups");
        israpied = PlayerPrefs.GetInt("QuickFire");
        isrico = PlayerPrefs.GetInt("Rico");
        isheath = PlayerPrefs.GetInt("Heath");
        isrocket = PlayerPrefs.GetInt("missle");
    }


    public void Checker()
    {
        Health = GameObject.FindGameObjectsWithTag("Healthpack");
        Rico = GameObject.FindGameObjectsWithTag("RicochetPickup");
        rocket = GameObject.FindGameObjectsWithTag("RocketPower");
        RapidFire = GameObject.FindGameObjectsWithTag("Rapid_Fire");
        total = new GameObject[Health.Length + Rico.Length + rocket.Length + RapidFire.Length];
        if (total.Length < numberOfObjects || isactive == 1)
        {

            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);

            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);

            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

            int num = Random.Range(1, 5);
            if(num == 1 && isheath == 1)
            {
                GameObject newObject = Instantiate(healthpp, new Vector3(posx, posy, posz), Quaternion.identity);
            }
            if (num == 2 && israpied ==1)
            {
                GameObject newObject = Instantiate(rapiedpp, new Vector3(posx, posy, posz), Quaternion.identity);
            }
            if (num == 3 && isrico == 1)
            {
                GameObject newObject = Instantiate(ricopp, new Vector3(posx, posy, posz), Quaternion.identity);
            }
            if (num == 4 && isrocket ==1)
            {
                GameObject newObject = Instantiate(rocketpp, new Vector3(posx, posy, posz), Quaternion.identity);
            }

           
            
        }
    }


}