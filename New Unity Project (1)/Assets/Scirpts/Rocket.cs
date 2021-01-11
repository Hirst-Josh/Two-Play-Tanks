using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public int RocketCount;
    public bool Isactive;
    public GameObject RocketProjectile;
    public GameObject RocketProjectileRic;
    GameObject spawn;
    public int number;
    int Count;
    
    bool lock1;
    public Transform Barrel1;
    bool lock2;
    public Transform Barrel2;
    bool lock3;
    public Transform Barrel3;
    bool lock4;
    public Transform Barrel4;
    bool lock5;
    public Transform Barrel5;
    bool lock6;
    public Transform Barrel6;
    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        number += 1;
        if (number == 1)
        {
            spawn = Instantiate(RocketProjectile, Barrel1.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
            
        }
        if (number == 2)
        {
            spawn = Instantiate(RocketProjectile, Barrel2.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
        
        }
        if (number == 3)
        {
            spawn = Instantiate(RocketProjectile, Barrel3.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
           
        }
        if (number == 4)
        {
            spawn = Instantiate(RocketProjectile, Barrel4.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
          
        }
        if (number == 5)
        {
            spawn = Instantiate(RocketProjectile, Barrel5.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
          
        }
        if (number == 6)
        {
            spawn = Instantiate(RocketProjectile, Barrel6.position, Quaternion.identity);
            spawn.gameObject.name = spawn.gameObject.name + Count;
          

        }
    }

    public void Setvisable()
    {

    }

    public void Invisable()
    {

    }
}
