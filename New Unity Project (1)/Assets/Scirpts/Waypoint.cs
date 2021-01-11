using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    float debugDrawRadius = 1.0F;
    readonly Transform location;
    string p1 = "Cube";
    string p2 = "Cube";

    GameObject mygameObject;

    void Start()
    {
        mygameObject = new GameObject(p1);
        mygameObject = new GameObject(p2);
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
       
    }

}
