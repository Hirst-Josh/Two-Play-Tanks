using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketric : MonoBehaviour
{
    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    public string Enemytag;
    private int hitcount = 0;
    public int hits;
    public bool player;
    public LayerMask CollisionMask;
    private float speed = 15;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
       
   
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.1f, CollisionMask))
        {
            Vector3 reflect = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflect.z, reflect.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        hitcount += 1;
        if (hitcount >= hits)
        {
            Destroy(gameObject);
        }
    }
}
