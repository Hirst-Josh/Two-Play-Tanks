using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missle_Script_Player : MonoBehaviour
{
    public int timebetweenshots;
    int shottimer;
    public int ammo;
    int maxammo;
    public TankDrive tankDrive;
    public float force = 100f;
    int ammoregan;
    public Transform barrelend;
    public Rigidbody shellprefab;
    public Rigidbody ricoprefab;
    bool fired;
    public int RocketCount;
    public int rico;
    bool shoot;
    bool shoot2;
    bool shoot3;
    public Text AmmoText;
    public Text RicoText;
    public Text Time_To_Reload;
    float time;
    public AudioClip MissleShooting;
    public AudioSource MyaudioSource;
    [SerializeField] public int ShotsFired;
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
    int oldtimebetweenshots;
    public Text rapidfiretext;
    private void Start()
    {
        maxammo = ammo;
        InvokeRepeating("checker", 0.0f, 0.1f);
        ShotsFired = 0;
        time = 0.0f;
    }

    void Awake()
    {
        fired = false;
    }

    private void checker()
    {
        if (tankDrive.shooting == true && time <= 0.0f)
        {
            Shoot();
        }
       

         if (tankDrive.shootingmissle == true && time <= 0.0f && tankDrive.shooting == false)
        {
            if (rico > 0)
            {
                Shootrico();
            }
            else
            {
                Shoot();
            }

        }
      

        if (tankDrive.shootingrico == true && time <= 0.0f && tankDrive.shooting == false)
        {
            if (rico > 0)
            {
                Shootrico();
            }
            else
            {
                Shoot();
            }
            
        }
       

        if (tankDrive.Grainammo == true)
        {
            StartCoroutine("GrainAmmo");
        }
        if (tankDrive.Grainammo == false)
        {
            StopCoroutine("GrainAmmo");
        }

        if (tankDrive.pickupRicochetPickup)
        {
            rico += 10;
            tankDrive.pickupRicochetPickup = false;
        }
        if (tankDrive.pickupRocketpowerup)
        {
            rico += 10;
            tankDrive.pickupRocketpowerup = false;
        }
        if (tankDrive.pickRapid_Fire)
        {
            rapidfire();
            tankDrive.pickRapid_Fire = false;
        }
        if (time > 0.0f)
        {
            time -= 0.1f;
        }

        AmmoText.text = ammo.ToString();
        RicoText.text = rico.ToString();
        Time_To_Reload.text = time.ToString();
    }

    void rapidfire()
    {
        oldtimebetweenshots = timebetweenshots;
        timebetweenshots = 1;
        rapidfiretext.text = "yes";
        Invoke("endRapiedfire", 10.0f);
    }
    void endRapiedfire()
    {
        timebetweenshots = oldtimebetweenshots;
        rapidfiretext.text = "no";
    }
      void   Shoot()
    {

       
                Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
                Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = -force * barrelend.forward;
                shell.GetComponent<MissleShell>().Spawner = gameObject;
                shell.GetComponent<MissleShell>().player = true;
                fired = true;
                fire();
                //play sound and effect
                // Debug.Log("shot");
                ShotsFired += 1;
                CheckBarrel();
                time = timebetweenshots;
                ammo -= 1;

                //SoundManager.PlaySound(SoundManager.Sound.Shoot, GetComponentInParent<AudioSource>().gameObject, true);
               // yield return new WaitForSeconds(3);
            
        
    }

    void Shootrico()
    {
       
                Rigidbody shell = Instantiate(ricoprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
                Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = -force * barrelend.forward;
                shell.GetComponent<MissleRic>().Spawner = gameObject;
                shell.GetComponent<MissleRic>().player = true;
                fired = true;
                fire();
                //play sound and effect
                CheckBarrel();
                Debug.Log("shotrico");
                time = timebetweenshots;
                rico -= 1;

               // yield return new WaitForSeconds(3);
            
        
    }
    IEnumerator GrainAmmo()
    {
        while (true)
        {
            if (ammo < maxammo)
            {
                ammo += ammoregan;
                if (ammo > maxammo)
                {
                    ammo = maxammo;
                }
            }
        }
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

        if (ShotsFired == 15)
        {
            ShotsFired = 0;
        }

    }

    void fire()
    {
        MyaudioSource.Play();
    }
}
