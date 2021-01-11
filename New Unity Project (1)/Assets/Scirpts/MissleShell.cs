using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleShell : MonoBehaviour
{
    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    public string Enemytag;
    public bool player;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, 15f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
