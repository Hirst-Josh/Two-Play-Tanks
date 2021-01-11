using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurrentLight : MonoBehaviour
{
    Transform target;
    public Transform hull;
    public float turrrentspeed = 1f;
    public int timebetweenshots;
    int shottimer;
    public bool shoot;
    Transform startpos;
    public float force = 50f;
    bool fired;
    public Tankfsm tankfsm;
    public Transform barrelend;
    public Transform barrelend2;
    public Rigidbody shellprefab;
    public Rigidbody RichetsShellPrefab;
    public Rigidbody RocketProjectile;
    private Tankfsm play;
    bool Barrel1;
    bool Barrel2;
    [SerializeField] public float Ammo;
    private float MaxAmmo;
    public float AmmoRegan;
    static float PercentageAmmo;
    public int RicochetShells;
    public int RocketCount;
    private Animator animator;
    public int DamageDone;
    public int ShotsFired;
    public GameObject ShootExplonsionprefab;
    public AudioClip Shooting;
    public AudioClip MissleShooting;
    void Start()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
        // target = 

        startpos = gameObject.transform;
        Barrel1 = true;
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
    }
    private void FixedUpdate()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
    }
    public void shootstart()
    {
        StartCoroutine("Shoot");
    }
    public void shootend()
    {
        StopCoroutine("Shoot");
    }

    private void info()
    {
        target = GetComponentInParent<Tankfsm>().Targett;
        //  tankfsm.ShotsFired = ShotsFired;
        //   tankfsm.DamageDone = DamageDone;
        animator.SetInteger("DamageDone", DamageDone);
        tankfsm.ShotsFired = ShotsFired;

        if (tankfsm.PickUpRicochet == true)
        {
            shells();
            tankfsm.PickUpRicochet = false;
        }
        if (tankfsm.HasRocket == true)
        {
            rockets();
            tankfsm.HasRocket = false;
        }
    }


    void shells()
    {
        RicochetShells += 12;
    }

    void rockets()
    {
        RocketCount += 7;
    }

    void Update()
    {



        if (shoot)
        {

            Quaternion TargetRotation = Quaternion.LookRotation(target.position - transform.position);

            float angle = Quaternion.Angle(TargetRotation, transform.rotation);

            if (Vector3.Dot(transform.TransformDirection(Vector3.right), (target.position - transform.position)) < 0f)
            {
                transform.RotateAround(hull.position, hull.forward, angle * (-1f) * Time.deltaTime * turrrentspeed);
            }
            else
            {
                transform.RotateAround(hull.position, hull.forward, angle * Time.deltaTime * turrrentspeed);
            }
        }

    }




    IEnumerator Shoot()
    {

        while (true)
        {


            if (tankfsm.Middle == true)
            {
                if (RicochetShells >= 4)
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
            yield return new WaitForSeconds(timebetweenshots);
        }

    }

    void shot()
    {
        if (Barrel1 == true)
        {
            Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            shell.name = tankfsm.gameObject.ToString();
            shell.GetComponent<shell2>().Spawner = tankfsm.gameObject;
            Ammo -= 1;
            PercentageAmmo = (Ammo / MaxAmmo) * 100;
            animator.SetFloat("AmmoCount", PercentageAmmo);
            shell.velocity = -force * barrelend.forward;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = false;
            Barrel2 = true;
        }

        if (Barrel2 == true)
        {
            Rigidbody shell = Instantiate(shellprefab, barrelend2.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            shell.name = tankfsm.gameObject.ToString();
            shell.GetComponent<shell2>().Spawner = tankfsm.gameObject;
            Ammo -= 1;
            PercentageAmmo = (Ammo / MaxAmmo) * 100;
            animator.SetFloat("AmmoCount", PercentageAmmo);
            shell.velocity = -force * barrelend2.forward;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = true;
            Barrel2 = false;
        }

    }
    public void Supportshoot()
    {
        Ammo -= 1;
        PercentageAmmo = Ammo / MaxAmmo * 100;
        animator.SetFloat("AmmoCount", PercentageAmmo);
    }

    void shotRicochet()
    {
        if (Barrel1 == true)
        {
            Rigidbody Ricocohet = Instantiate(RichetsShellPrefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            Ricocohet.name = tankfsm.gameObject.ToString();
            Ricocohet.GetComponent<Ricochet>().Spawner = tankfsm.gameObject;
            RicochetShells -= 1;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = false;
            Barrel2 = true;
        }

        if (Barrel2 == true)
        {
            Rigidbody Ricocohet = Instantiate(RichetsShellPrefab, barrelend2.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            Ricocohet.name = tankfsm.gameObject.ToString();
            Ricocohet.GetComponent<Ricochet>().Spawner = tankfsm.gameObject;
            RicochetShells -= 1;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = true;
            Barrel2 = false;
        }
    }

    void fireRocket()
    {
        if (Barrel1 == true)
        {
            Rigidbody spawn = Instantiate(RocketProjectile, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            spawn.name = tankfsm.gameObject.ToString();
            spawn.GetComponent<Ricochet>().Spawner = gameObject;
            RocketCount -= 1;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = false;
            Barrel2 = true;
        }

        if (Barrel2 == true)
        {
            Rigidbody spawn = Instantiate(RocketProjectile, barrelend2.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
            spawn.name = tankfsm.gameObject.ToString();
            spawn.GetComponent<Ricochet>().Spawner = gameObject;
            RocketCount -= 1;
            tankfsm.shoot();
            ShotsFired += 1;
            Barrel1 = true;
            Barrel2 = false;
        }
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
            Debug.Log(Ammo);
            PercentageAmmo = (Ammo / MaxAmmo) * 100;
            animator.SetFloat("AmmoCount", PercentageAmmo);
            yield return new WaitForSeconds(1);
        }
        if (Ammo > MaxAmmo)
        {
            Ammo = MaxAmmo;
        }
    }

    public void GrainAmmo()
    {
        Ammo += 4;
    }

    public void Death()
    {
        StopCoroutine("Shoot");
        StopCoroutine("RestoreAmmo");
        shoot = false;
    }

}
