using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTurrent : MonoBehaviour
{

    // Update is called once per frame
    Transform target;
    public Transform hull;
    public float turrrentspeed = 1f;
    public int timebetweenshots;
    int shottimer;
    [SerializeField] public float Ammo;
    private float MaxAmmo;
    public float AmmoRegan;
    static float PercentageAmmo;
    private Animator animator;
    public Tankfsm tankfsm;


    public bool shoot;
    Transform startpos;
    public float force = 50f;
    bool fired;
    public int DamageDone;
    public int ShotsFired;
    public int RocketCount;
    public bool rocket;
    public Transform barrelend;
    public Rigidbody shellprefab;
    public Rigidbody RichetsShellPrefab;
    public Rigidbody RocketProjectile;
    public Tankfsm play;
    public int RicochetShells;
    public Rocket MyRocket;
    public GameObject ShootExplonsionprefab;
    public AudioClip Shooting;
    public AudioClip MissleShooting;
    public AudioSource MyaudioSource;
    int oldtimebetweenshots;
    public bool israpidfire;
    void Start()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
        // target = 

        startpos = gameObject.transform;
        // shellsmax = shells;
        InvokeRepeating("info", 0.1f, 0.5f);
    }

     void Awake()
     {
        animator = GetComponentInParent<Animator>();
        fired = true;
        MaxAmmo = Ammo;
        PercentageAmmo = (Ammo / MaxAmmo) * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
        RicochetShells = 0;
        rocket = false;
        israpidfire = false;
    }
    private void info()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
        tankfsm.ShotsFired = ShotsFired;
     //   tankfsm.DamageDone = DamageDone;
        animator.SetInteger("DamageDone", DamageDone);
       // animator.SetInteger("ShotsHits", ShotsFired);
        if(tankfsm.PickUpRicochet == true)
        {
            shells();
            tankfsm.PickUpRicochet = false;
        }
        if(tankfsm.HasRocket == true)
        {
            rockets();
            tankfsm.HasRocket = false;
        }
        if (tankfsm.HasRapiedfire == true)
        {
            rapidfire();
            tankfsm.HasRapiedfire = false;
        }
    }
    public void shootstart()
    {
        StartCoroutine("Shoot");
    }
    public void shootend()
    {
        StopCoroutine("Shoot");
    }
    void shells()
    {
        RicochetShells += 12;
    }

    void rockets()
    {
        RocketCount += 7;
    }
    void rapidfire()
    {
        oldtimebetweenshots = timebetweenshots;
        timebetweenshots = 1;
        israpidfire = true;
        Invoke("endRapiedfire", 10.0f);
    }
    void endRapiedfire()
    {
        israpidfire = false;
        timebetweenshots = oldtimebetweenshots;
    }

    void Update()
    {

       // shellscount = (shells / shellsmax) * 100;
        //animator.SetFloat("ShellCount", shellscount);

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

            
            if(tankfsm.Middle == true)
            {
                if(RicochetShells >= 4)
                {
                    shotRicochet();
                }
                else if (RocketCount >= 1)
                {
                    fireRocket();
                }
                else
                {
                    shot();
                }
                
            }
            if (tankfsm.Heavy == true)
            {
                if(RocketCount >= 1)
                {
                    fireRocket();
                }
                else if(RicochetShells >= 1)
                {
                    shotRicochet();
                }
                else
                {
                    shot();
                }
            }
            if (tankfsm.Light == true)
            {

            }
            if (tankfsm.MG == true)
            {

            }
            if (tankfsm.Missle == true)
            {
                if (RocketCount >= 1)
                {
                    fireRocket();
                }
                else if (RicochetShells >= 1)
                {
                    shotRicochet();
                }
                else
                {
                    shot();
                }
            }
            if (tankfsm.MBT == true)
            {
                if (RocketCount >=1)
                {
                    fireRocket();
                }
                else if (RicochetShells >= 1)
                {
                    shotRicochet();
                }
                else
                {
                    shot();
                }
            }
            yield return new WaitForSeconds(timebetweenshots);
        }

    }

    void shot()
    {
        Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        shell.name = tankfsm.gameObject.ToString();
        shell.GetComponent<shell2>().Spawner = tankfsm.gameObject;
        Ammo -= 1;
        PercentageAmmo = (Ammo / MaxAmmo) * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
        shell.velocity = -force * barrelend.forward;
        tankfsm.shoot();
        ShotsFired += 1;
        MyaudioSource.clip = Shooting;
        MyaudioSource.Play();
    }
    public void Supportshoot()
    {
        Ammo -= 1;
        PercentageAmmo = Ammo / MaxAmmo * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
        // shooting sound for support conmes from support
    }

    void shotRicochet()
    {
        Rigidbody Ricocohet = Instantiate(RichetsShellPrefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        Ricocohet.name = tankfsm.gameObject.ToString();
        Ricocohet.GetComponent<Ricochet>().Spawner = tankfsm.gameObject;
        RicochetShells -= 1;
        tankfsm.shoot();
        ShotsFired += 1;
        MyaudioSource.clip = Shooting;
        MyaudioSource.Play();
    }

    void fireRocket()
    {
        
        Rigidbody spawn = Instantiate(RocketProjectile, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        spawn.name = tankfsm.gameObject.ToString();
        spawn.GetComponent<MissleShell>().Spawner = gameObject;
        RocketCount -= 1;
        tankfsm.shoot();
        ShotsFired += 1;
        MyaudioSource.clip = MissleShooting;
        MyaudioSource.Play();
    }

    public void StartAmmo()
    {
        StartCoroutine("RestoreAmmo"); 
    }
    public void StopAmmo()
    {
        StopCoroutine("RestoreAmmo");
    }
    IEnumerator RestoreAmmo()
    {
        while (Ammo < MaxAmmo)
        {
            GrainAmmo();
           // Debug.Log(Ammo);
            PercentageAmmo = (Ammo / MaxAmmo) * 100;
            animator.SetFloat("AmmoCount", PercentageAmmo);
            yield return new WaitForSeconds(1);
        }
        if(Ammo > MaxAmmo)
        {
            Ammo = MaxAmmo;
        }
    }

    public void GrainAmmo()
    {
        Ammo +=  4;
    }

    public void Death()
    {
        StopCoroutine("Shoot");
        StopCoroutine("RestoreAmmo");
        shoot = false;
    }
    
}




