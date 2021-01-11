using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    // Start is called before the first frame update
    //shellparticles

    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, 5f);
        Debug.Log("start");
    }

   private void OnCollisionEnter(Collision collision)
   {
        if(collision.collider.GetComponentInParent<Tankfsm>() != null)
       {
           collision.collider.GetComponentInParent<Tankfsm>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);
           damage = Random.Range(MinPerToTake, MaxPerToTake);
        }
        Debug.Log("hit" + collision.collider.name);
        Debug.Log(damage);
       
   }

}
