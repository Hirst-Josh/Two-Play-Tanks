using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supportTurrent : MonoBehaviour
{
    Transform target;
    public Transform hull;
    public float turrrentspeed = 1f;
    public int timebetweenshots;
    int shottimer;
    private float MaxAmmo;
    public float AmmoRegan;
    bool fired;
    public float force = 100f;
    public Transform barrelend;
    public Rigidbody shellprefab;
    public Tankfsm tankfsm;
    public AiTurrent mainturrent;
    public bool shoot;
    public GameObject ShootExplonsionprefab;
    public AudioSource Shooting;
    int oldtimebetweenshots;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("checker", 0.0f, 0.1f);
    }
    void Awake()
    {
        fired = true;
    }

    private void checker()
    {
      //  if(mainturrent.israpidfire == true)
       // {
       //     oldtimebetweenshots = timebetweenshots;
       //     timebetweenshots = 1;
      //  }
      //  else
      //  {
      //      timebetweenshots = oldtimebetweenshots;
      //  }
    }
        // Update is called once per frame
        private void FixedUpdate()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
    }

    void shot()
    {
        Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        shell.GetComponent<shell2>().Spawner = gameObject;
        //Ammo = Ammo - 1f;
        shell.velocity = -force * barrelend.forward;
        //tankfsm.shoot();
        mainturrent.Supportshoot();
        Shooting.Play();
    }

    public void shootstart()
    {
        StartCoroutine("Shoot");
    }
    public void shootend()
    {
        StopCoroutine("Shoot");
    }

    void Update()
    {

 

        if (shoot)
        {




            Quaternion TargetRotation = Quaternion.LookRotation(target.position - transform.position);

            float angle = Quaternion.Angle(TargetRotation, transform.rotation);

            if (Vector3.Dot(transform.TransformDirection(Vector3.right), (target.position - transform.position)) < 0f)
            {
                transform.RotateAround(hull.position, hull.up, angle * (-1f) * Time.deltaTime * turrrentspeed);
            }
            else
            {
                transform.RotateAround(hull.position, hull.up, angle * Time.deltaTime * turrrentspeed);
            }
        }

    }

    IEnumerator Shoot()
    {

        while (true)
        {

            shot();

            yield return new WaitForSeconds(timebetweenshots);
        }

    }
}
