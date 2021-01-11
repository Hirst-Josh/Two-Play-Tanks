using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gunscript : MonoBehaviour
{
    public int timebetweenshots;
   // int shottimer;
    public int ammo;
    int maxammo;
    public TankDrive tankDrive;
    public float force = 100f;
    int ammoregan;
    public Transform barrelend;
    public Rigidbody shellprefab;
    public Rigidbody missleshellprefab;
    public Rigidbody ricoprefab;
    bool fired;
    public int RocketCount;
    public int rico;
    bool shoot;
    bool shoot2;
    bool shoot3;
    public Text AmmoText;
    public Text RicoText;
    public Text RocketText;
    public Text Time_To_Reload;
    float time;
    public AudioSource Gun;
    public GameObject ShootExplonsionprefab;
    int oldtimebetweenshots;
    public Text rapidfireText;
    private void Start()
    {
        maxammo = ammo;
        InvokeRepeating("checker", 0.0f, 0.1f);
        time = 0.0f;
        rapidfireText.text = "no";
    }

    void Awake()
    {
        fired = false;
    }

    private void checker()
    {
        if(tankDrive.shooting == true && time <= 0.0f)
        {
            Shoot();
        }


        if (tankDrive.shootingmissle == true && time <= 0.0f && tankDrive.shooting == false)
        {
            if (RocketCount > 0)
            {
                ShootMissle();
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
  

        if (tankDrive.Grainammo == true && tankDrive.DisToSpawn <= 10.0f)
        {
            StartCoroutine("GrainAmmo");
        }
        if (tankDrive.Grainammo == false || tankDrive.DisToSpawn >= 10.0f)
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
            RocketCount += 10;
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

        RocketText.text = RocketCount.ToString();
        AmmoText.text = ammo.ToString();
        RicoText.text = rico.ToString();
        Time_To_Reload.text = time.ToString();



    }

    void rapidfire()
    {
        oldtimebetweenshots = timebetweenshots;
        timebetweenshots = 1;
        rapidfireText.text = "yes";
        Invoke("endRapiedfire", 10.0f);
    }
    void endRapiedfire()
    {
        timebetweenshots = oldtimebetweenshots;
        rapidfireText.text = "no";
    } 

    void Shoot()
    {

        
            
                Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
                Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = force * barrelend.forward;
                shell.GetComponent<shell2>().Spawner = gameObject;
                shell.GetComponent<shell2>().player = true;
                fired = true;
                fire();
                //play sound and effect
                // Debug.Log("shot");

                ammo -= 1;

                //SoundManager.PlaySound(SoundManager.Sound.Shoot, GetComponentInParent<AudioSource>().gameObject, true);
                time = timebetweenshots;
                //yield return new WaitForSeconds(3);
            

        
    }


    void ShootMissle()
    {

        
            
                Rigidbody shell = Instantiate(missleshellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
                Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = force * barrelend.forward;
                shell.GetComponent<MissleShell>().Spawner = gameObject;
                shell.GetComponent<MissleShell>().player = true;
                fired = true;
                fire();
                //play sound and effect

                Debug.Log("shotmissle");
                
                RocketCount -= 1;
                time = timebetweenshots;
                //yield return new WaitForSeconds(3);
            
        

    }

    void Shootrico()
    {
        
              Rigidbody shell = Instantiate(ricoprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
        Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = -force * barrelend.forward;
                shell.GetComponent<Ricochet>().Spawner = gameObject;
                shell.GetComponent<Ricochet>().player = true;
                fired = true;
                fire();
                //play sound and effect
                Debug.Log("shotrico");
               
                rico -= 1;
                time = timebetweenshots;
                //yield return new WaitForSeconds(3);
            

        
    }
    IEnumerator GrainAmmo()
    {
        while (true)
        {
            if(ammo < maxammo)
            {
                ammo += ammoregan;
                if(ammo > maxammo)
                {
                    ammo = maxammo;
                }
            }
        }
    }

    void fire()
    {
        Gun.Play();
    }
  
}
