using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell2 : MonoBehaviour
{
    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    public string Enemytag;
    public bool player;
    public GameObject Explonsionprefab;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, 5f);
       // Debug.Log("start");
    }

    void OnCollisionEnter(Collision collision)
    {
             if(collision.gameObject.GetComponentInParent<Team1Tracker>() ==false && collision.gameObject.GetComponentInParent<Team2Tracker>() == false)
           {
            // damage = Random.Range(MinPerToTake, MaxPerToTake);
            // collision.collider.GetComponentInParent<Tankfsm>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);
            //  Debug.Log("hit" + collision.collider.name);
            //  Debug.Log(damage);
            Instantiate(Explonsionprefab, collision.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);

        }
         
          
        //Destroy(gameObject);
       // Debug.Log("hit" + collision.collider.name);

    }

}
