using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentArmour : MonoBehaviour
{
    public int resistance;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public DamageResistance test;
    public string EnemyString;
    public Tankfsm tankfsm;


    private void Awake()
    {
        EnemyString = transform.parent.GetComponentInParent<Tankfsm>().Enemytag;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<shell2>().Enemytag == EnemyString)

        {
            damage = Random.Range(MinPerToTake, MaxPerToTake);
            tankfsm.GetComponent<Tankfsm>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);
            
            

        }



        Debug.Log("hit by" + collision.collider.name);


    }
}
