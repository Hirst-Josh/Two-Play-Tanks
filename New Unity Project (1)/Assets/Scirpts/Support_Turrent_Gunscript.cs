using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Support_Turrent_Gunscript : MonoBehaviour
{
    // Start is called before the first frame update
    public int timebetweenshots;
    public TankDrive tankDrive;
    public float force = 100f;
    int ammoregan;
    public Transform barrelend;
    public Rigidbody shellprefab;
    bool fired;
    public int RocketCount;
    public int rico;
    bool shoot;
    bool shoot2;
    bool shoot3;
    public Text Time_To_Reload;
    float time;
    public AudioSource Gun;
    public GameObject ShootExplonsionprefab;
    public Gunscript gunscript;
    int oldtimebetweenshots;
    private void Start()
    {
        InvokeRepeating("checker", 0.0f, 0.1f);
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
            Shoot();

        }
       
         if (tankDrive.shootingrico == true && time <= 0.0f && tankDrive.shooting == false)
        {
            Shoot();

        }

        if (tankDrive.Grainammo == true)
        {
            StartCoroutine("GrainAmmo");
        }
        if (tankDrive.Grainammo == false)
        {
            StopCoroutine("GrainAmmo");
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
        Time_To_Reload.text = time.ToString();

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

    void Shoot()
    {

        
            
                Rigidbody shell = Instantiate(shellprefab, barrelend.position, Quaternion.Euler(0, 0, 0)) as Rigidbody;
                Instantiate(ShootExplonsionprefab, barrelend.transform.position, Quaternion.Euler(0, 0, 0));
                shell.velocity = -force * barrelend.forward;
                shell.GetComponent<shell2>().Spawner = gameObject;
                shell.GetComponent<shell2>().player = true;
                fired = true;
                fire();
                //play sound and effect
                // Debug.Log("shot");

                time = timebetweenshots;
                gunscript.ammo -= 1;

                //SoundManager.PlaySound(SoundManager.Sound.Shoot, GetComponentInParent<AudioSource>().gameObject, true);
                //yield return new WaitForSeconds(3);
            
        
    }
 
    void fire()
    {
        Gun.Play();
    }
}
