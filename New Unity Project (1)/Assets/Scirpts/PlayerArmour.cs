using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmour : MonoBehaviour
{
    public int resistance;
    [SerializeField] private int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] private int MinPerToTake;
    [SerializeField] private int MaxPerToTake;
    public DamageResistance test;
    public string EnemyString;
    public TankDrive TankDrive;

    private void Awake()
    {
        EnemyString = GetComponentInParent<TankDrive>().Enemytag;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == EnemyString)
        {
            damage = Random.Range(MinPerToTake, MaxPerToTake);
            TankDrive.GetComponent<TankDrive>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);
            Destroy(collision.gameObject);

        }
        Debug.Log("hit by" + collision.collider.name);
        Debug.Log(damage);
 
    }
}
