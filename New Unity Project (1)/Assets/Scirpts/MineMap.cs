using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineMap : MonoBehaviour
{
    
    public int MapSizeZ;
    public int MapSizX;
    public Vector3 Playerpos;
    public GameObject player;
    public bool player_Alive;
    public float tempx;
    public float tempz;
    public Vector3 MAP;
    public Image playericon;
    void Update()
    {
        if(player_Alive == true)
        {
            Playerpos = player.transform.position;
            tempx = Playerpos.x / MapSizX * 100;
            tempz = Playerpos.z / MapSizeZ * 100;//woks out percent
            MAP.x = tempx;
            MAP.y = tempz;
            MAP.z = 0.0f;
            playericon.transform.position = MAP;




        }
    }
}
