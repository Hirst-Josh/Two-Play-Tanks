using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleTurrent : MonoBehaviour
{

    Transform target;
    public Transform hull;
    public float turrrentspeed = 1f;
    public int timebetweenshots;
    public int RicochetShells;
    public Rigidbody MisslePrefab;
    public Rigidbody RichetsMisslePrefab;
    public bool rocket;
    private float MaxAmmo;
    public float force = 50f;
    [SerializeField] public float Ammo;
    public int AmmoRegan;
    private Animator animator;
    bool fired;
    public bool shoot;
    public Tankfsm tankfsm;
    public Transform barrelend;
    [SerializeField] public int ShotsFired;
    public bool PowerUpReloadUsed;
    int ReloadPowerUp;
    [SerializeField] public int ReloadPowerPickUP;
    public bool Reloading;
    static float PercentageAmmo;
    public Transform Barrel1;
    public Transform Barrel2;
    public Transform Barrel3;
    public Transform Barrel4;
    public Transform Barrel5;
    public Transform Barrel6;
    public Transform Barrel7;
    public Transform Barrel8;
    public Transform Barrel9;
    public Transform Barrel10;
    public Transform Barrel11;
    public Transform Barrel12;
    public Transform Barrel13;
    public Transform Barrel14;
    public Transform Barrel15;
    public GameObject ShootExplonsionprefab;
    public AudioClip ShootingFast;
    public AudioClip MissleShooting;
    public AudioSource MyaudioSource;
    int oldtimebetweenshots;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
       timebetweenshots = 2;
        shoot = false;
    }

    private void Awake()
    {
        fired = true;
        MaxAmmo = Ammo;
        animator = GetComponentInParent<Animator>();
        RicochetShells = 0;
        rocket = false;
        ShotsFired = 0;
        PowerUpReloadUsed = false;
        Reloading = false;
        barrelend = Barrel1;
        PercentageAmmo = (Ammo / MaxAmmo) * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
        StopCoroutine("Shoot");
        InvokeRepeating("info", 0.1f, 0.5f);
        shoot = false;
    }

    // Update is called once per frame
    private void info()
    {
        target = GetComponentInParent<Tankfsm>().Targett;

        if (tankfsm.PickUpRicochet == true)
        {
            shells();
            tankfsm.PickUpRicochet = false;
        }
        if (tankfsm.HasRocket == true)
        {
            ReloadPowerUp += ReloadPowerPickUP;
            tankfsm.HasRocket = false;
        }



        if (ShotsFired >= 15)
        {
            animator.SetBool("Reloading", true);
           // StartCoroutine("Loading");
            Reloading = true;
            ShotsFired = 0;
            timebetweenshots = 12;
            if (PowerUpReloadUsed == true)
            {
                
                PowerUpReloadUsed = false;
                Debug.Log("ishgisha");
            }

            if(tankfsm.HasRapiedfire == true && PowerUpReloadUsed == false)
            {
                rapidfire();
            }
            
        }

    }

    void rapidfire()
    {
        oldtimebetweenshots = timebetweenshots;
        timebetweenshots = 1;
        Invoke("endRapiedfire", 10.0f);
    }
    void endRapiedfire()
    {
        timebetweenshots = oldtimebetweenshots;
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

    public void ReloadingCouroutine()
    {
        StartCoroutine("Loading");
        Reloading = true;
    }

    IEnumerator Loading()
    {
        while (true)
        {
            yield return new WaitForSeconds(12);
            animator.SetBool("Reloading", false);
            Reloading = false;
            StopCoroutine("Loading");
        }
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
            if (shoot == true)
            {


                if (tankfsm.Middle == true)
                {
                    if (RicochetShells > 0)
                    {
                        shotRicochet();
                    }
                    else if (ReloadPowerUp > 0)
                    {
                        Reload();
                    }
                    else
                    {
                        shot();
                        Debug.Log("shot");
                    }



                }
                if (tankfsm.Heavy == true)
                {
                    if (ReloadPowerUp >= 1)
                    {
                        Reload();
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
                if (tankfsm.Light == true)
                {

                }
                if (tankfsm.MG == true)
                {

                }
                if (tankfsm.Missle == true)
                {
                    if (ReloadPowerUp >= 1)
                    {
                        Reload();
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
                    if (RicochetShells >= 1)
                    {
                        shotRicochet();
                    }
                    else
                    {
                        shot();
                    }
                }

                yield return new WaitForSeconds(timebetweenshots);
                if (Reloading == true)
                {
                    timebetweenshots = 2;
                }
            }
        }

    }

    void shot()
    {
        Rigidbody shell = Instantiate(MisslePrefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        shell.name = tankfsm.gameObject.ToString();
        shell.GetComponent<MissleShell>().Spawner = tankfsm.gameObject;
        Ammo -= 1;
        PercentageAmmo = Ammo / MaxAmmo * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
        shell.velocity = -force * barrelend.forward;
        tankfsm.shoot();
        ShotsFired += 1;
        Debug.Log(ShotsFired);
        CheckBarrel();
        MyaudioSource.clip = MissleShooting;
        MyaudioSource.Play();

    }

    void shotRicochet()
    {
        Rigidbody Ricocohet = Instantiate(RichetsMisslePrefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
        Ricocohet.GetComponent<MissleRic>().Spawner = gameObject;
        Ricocohet.name = tankfsm.gameObject.ToString();
        RicochetShells -= 1;
        tankfsm.shoot();
        ShotsFired += 1;
        CheckBarrel();
        MyaudioSource.clip = ShootingFast;
        MyaudioSource.Play();
    }
    void Reload()
    {
        Debug.Log("jshfhsiofhaohf");
        timebetweenshots = 1;
        ShotsFired = 0;
        PowerUpReloadUsed = true;
        CheckBarrel();
    }
    void CheckBarrel()
    {
        if (ShotsFired == 0)
        {
            barrelend = Barrel1.transform;
        }

        if (ShotsFired == 1)
        {
            barrelend = Barrel2.transform;
        }
        if (ShotsFired == 2)
        {
            barrelend = Barrel3.transform;
        }
        if (ShotsFired == 3)
        {
            barrelend = Barrel4.transform;
        }
        if (ShotsFired == 4)
        {
            barrelend = Barrel5.transform;
        }
        if (ShotsFired == 5)
        {
            barrelend = Barrel6.transform;
        }
        if (ShotsFired == 6)
        {
            barrelend = Barrel7.transform;
        }
        if (ShotsFired == 7)
        {
            barrelend = Barrel8.transform;
        }
        if (ShotsFired == 8)
        {
            barrelend = Barrel9.transform;
        }
        if (ShotsFired == 9)
        {
            barrelend = Barrel10.transform;
        }
        if (ShotsFired == 10)
        {
            barrelend = Barrel11.transform;
        }
        if (ShotsFired == 11)
        {
            barrelend = Barrel12.transform;
        }
        if (ShotsFired == 12)
        {
            barrelend = Barrel13.transform;
        }
        if (ShotsFired == 13)
        {
            barrelend = Barrel14.transform;
        }
        if (ShotsFired == 14)
        {
            barrelend = Barrel15.transform;
        }
       
    }

    IEnumerator RestoreAmmo()
    {
        while (Ammo < MaxAmmo)
        {
            GrainAmmo();
            yield return new WaitForSeconds(1);
        }
    }

    public void GrainAmmo()
    {
        Ammo += AmmoRegan;
    }

    public void Death()
    {
        StopCoroutine("Shoot");
        StopCoroutine("RestoreAmmo");
        shoot = false;
    }
}
