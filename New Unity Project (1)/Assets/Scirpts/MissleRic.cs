using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleRic : MonoBehaviour
{
    public LayerMask CollisionMask;
    private float speed = 15;
    private int hitcount = 0;
    public int hits;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    public string Enemytag;
    public bool player;
    private void Start()
    {
        hitcount = 0;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

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
