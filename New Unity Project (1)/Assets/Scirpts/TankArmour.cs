using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankArmour : MonoBehaviour
{
    public float resistance;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public DamageResistance test;
    public string EnemyTag;
    public string EnemyTag2;
    public Tankfsm tankfsm;
    Vector3 temp;
    public TankDrive tankDrive;
    public string health;
    public bool forplayer;
    GameObject CollsionSpawner;
    float HealthToAdd;
    private string Name;
    private GameObject T;
    public GameObject Explonsionprefab;
    public GameObject RicoExplonsionprefab;
    public GameObject RocketExplonsionprefab;
    public AudioClip ImpactSound;
    public AudioClip ImpactExplosions;
    public AudioSource MyaudioSource;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == EnemyTag)
        {

           

            if ( forplayer == true ||tankfsm.Deathis == false)
            {

                if (collision.gameObject.GetComponent<shell2>())
                {
                    temp = collision.transform.position;
                    Instantiate(Explonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                   // SoundManager.PlaySound(SoundManager.Sound.explosions,GetComponentInParent<AudioSource>().gameObject,true);
                    MinPerToTake = collision.gameObject.GetComponent<shell2>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<shell2>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake) ;
                    damage = (int)(damage * resistance);
                    Name = collision.gameObject.GetComponent<shell2>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<shell2>().Spawner;
                    CollsionSpawner = collision.gameObject.GetComponent<shell2>().Spawner;
                    MyaudioSource.clip = ImpactSound;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<shell2>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneByShell += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShellsHit += 1;
                        T = CollsionSpawner.GetComponent<Tankfsm>().gameObject;
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        Debug.Log("player1");
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDoneByShell += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShellsHit += 1;
                        lasthit();
                        Destroy(collision.gameObject);
                    }
                    if(forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByShells += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByShells += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                        
                    }

                }

                if (collision.gameObject.GetComponent<Ricochet>())
                {
                    temp = collision.transform.position;
                    Instantiate(RicoExplonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                   // SoundManager.PlaySound(SoundManager.Sound.explosions,GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<Ricochet>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<Ricochet>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    CollsionSpawner = collision.gameObject.GetComponent<Ricochet>().Spawner;
                    Name = collision.gameObject.GetComponent<Ricochet>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<Ricochet>().Spawner;
                    MyaudioSource.clip = ImpactSound;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<Ricochet>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneByRichet += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().RichetsShellhit += 1;
                        T = CollsionSpawner.GetComponent<Tankfsm>().gameObject;
                    }
                    else
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageByRichet += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().RichetsShellhit += 1;
                        lasthit();
                    }

                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByRichet += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByRichet += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                        
                    }

                }
                if (collision.gameObject.GetComponent<RocketShell>())
                {
                    temp = collision.transform.position;
                    Instantiate(RocketExplonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                 //   SoundManager.PlaySound(SoundManager.Sound.explosions, GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<RocketShell>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<RocketShell>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    CollsionSpawner = collision.gameObject.GetComponent<RocketShell>().Spawner;
                    Name = collision.gameObject.GetComponent<RocketShell>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<RocketShell>().Spawner;
                    MyaudioSource.clip = ImpactExplosions;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<RocketShell>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneByRockets += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().RocketsFiredHit += 1;
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageByRockets += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().RocketsFiredHit += 1;
                        lasthit();
                        Destroy(collision.gameObject);
                    }

                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByRockets += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByRockets += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                    }
                }

                if (collision.gameObject.GetComponent<Rocketric>())
                {
                    temp = collision.transform.position;
                    Instantiate(RocketExplonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                 //   SoundManager.PlaySound(SoundManager.Sound.explosions, GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<Rocketric>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<Rocketric>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    CollsionSpawner = collision.gameObject.GetComponent<Rocketric>().Spawner;
                    Name = collision.gameObject.GetComponent<Rocketric>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<RocketShell>().Spawner;
                    MyaudioSource.clip = ImpactExplosions;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<Rocketric>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneByRocketRic += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().RocketRicHit += 1;
                    }
                    else
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamgeByRocketRic += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().RocketRicHit += 1;
                        tankDrive.GetComponent<TankDrive>().LastHitby = Name;

                    }
                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByRocketRic += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByRocketRic += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                    }
                }

                if (collision.gameObject.GetComponent<MissleShell>())
                {
                    temp = collision.transform.position;
                    Instantiate(RocketExplonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                 //   SoundManager.PlaySound(SoundManager.Sound.explosions, GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<MissleShell>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<MissleShell>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    CollsionSpawner = collision.gameObject.GetComponent<MissleShell>().Spawner;
                    Name = collision.gameObject.GetComponent<MissleShell>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<MissleShell>().Spawner;
                    MyaudioSource.clip = ImpactExplosions;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<MissleShell>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneByMissle += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().MissleHit += 1;
                        
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageByMissle += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().MissleHit += 1;
                        lasthit();
                    }

                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByMissle += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByMissle += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                    }
                }
                if (collision.gameObject.GetComponent<MissleRic>())
                {
                    temp = collision.transform.position;
                    Instantiate(RocketExplonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                  //  SoundManager.PlaySound(SoundManager.Sound.explosions, GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<MissleRic>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<MissleRic>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    CollsionSpawner = collision.gameObject.GetComponent<MissleRic>().Spawner;
                    Name = collision.gameObject.GetComponent<MissleRic>().Spawner.ToString();
                    T = collision.gameObject.GetComponent<MissleRic>().Spawner;
                    MyaudioSource.clip = ImpactExplosions;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<MissleRic>().player == false)
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDoneBYMissleRic += damage;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<Tankfsm>().MissleRicHit += 1;
                    }
                    else
                    {
                        dealdamageto();
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().DamageBYMissleRic += damage;
                        CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                        CollsionSpawner.GetComponentInParent<TankDrive>().MissleRicHit += 1;
                        lasthit();
                    }
                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByMissleRic += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByMissleRic += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                    }
                }
                if (collision.gameObject.GetComponent<Mineteam>())
                {
                    temp = collision.transform.position;
                    Instantiate(Explonsionprefab, temp, Quaternion.Euler(0, 0, 0));
                  //  SoundManager.PlaySound(SoundManager.Sound.explosions, GetComponentInParent<AudioSource>().gameObject, true);
                    MinPerToTake = collision.gameObject.GetComponent<Mineteam>().MinPerToTake;
                    MaxPerToTake = collision.gameObject.GetComponent<Mineteam>().MaxPerToTake;
                    damage = Random.Range(MinPerToTake, MaxPerToTake);
                    damage = (int)(damage * resistance);
                    MyaudioSource.clip = ImpactExplosions;
                    MyaudioSource.Play();
                    if (collision.gameObject.GetComponent<Mineteam>().Spawner != null)
                    {
                     CollsionSpawner = collision.gameObject.GetComponent<Mineteam>().Spawner;
                     Name = collision.gameObject.GetComponent<Mineteam>().Spawner.ToString();
                     T = collision.gameObject.GetComponent<Mineteam>().Spawner;
                    }
                   
                    if (collision.gameObject.GetComponent<Mineteam>().player == false)
                    {
                        dealdamageto(); 
                        if (collision.gameObject.GetComponent<Mineteam>().Spawner != null)
                        {
                         CollsionSpawner.GetComponentInParent<Tankfsm>().DamageDone += damage;
                         CollsionSpawner.GetComponentInParent<Tankfsm>().DamgeByDoneMineTeam += damage;
                         CollsionSpawner.GetComponentInParent<Tankfsm>().ShotsHits += 1;
                         CollsionSpawner.GetComponentInParent<Tankfsm>().MineTeamHit += 1;
                        }
                    }
                    else
                    {
                        dealdamageto();
                        if (collision.gameObject.GetComponent<Mineteam>().Spawner != null)
                        {
                         CollsionSpawner.GetComponentInParent<TankDrive>().DamageDone += damage;
                         CollsionSpawner.GetComponentInParent<TankDrive>().DamgeByMineTeam += damage;
                         CollsionSpawner.GetComponentInParent<TankDrive>().ShotsHits += 1;
                         CollsionSpawner.GetComponentInParent<TankDrive>().MineTeamHit += 1;
                        }
                        lasthit();
                    }
                    if (forplayer == false)
                    {
                        tankfsm.HealthDamage += damage;
                        tankfsm.HealthDamageByMineTeam += damage;
                        tankfsm.LastHitby = Name;
                        tankfsm.killedby = T;
                    }
                    else
                    {
                        tankDrive.HealthDamage += damage;
                        tankDrive.HealthDamageByMineTeam += damage;
                        tankDrive.LastHitby = Name;
                        tankDrive.killedby = T;
                    }
                }

               
            }
        }
        if (collision.gameObject.tag == "Healthpack")
        {
            if (forplayer == false)
            {
                // Debug.Log("liafgagfgilagi");
                HealthToAdd = tankfsm.Heal;
                tankfsm.healthpacktoadd = HealthToAdd;
                tankfsm.HealthPackHeal();
                // Debug.Log(collision.collider.name + "healed" + HealthToAdd);
                tankfsm.Healthpackend();
                tankfsm.HealthPacksUsed += 1;
                Destroy(collision.gameObject);
            }
            else
            {
                HealthToAdd = tankDrive.Heal;
                tankDrive.healthpacktoadd = HealthToAdd;
                tankDrive.HealthPackHeal();
                tankDrive.HealthPacksUsed += 1;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "RicochetPickup")
        {
            Debug.Log("sa\f\fffa");
            if (forplayer == false)
            {
                tankfsm.PickUpRicochet = true;
                tankfsm.RicohetPowerupEnd();
                tankfsm.RicohetPackpickup += 1;
                Destroy(collision.gameObject);
            }
            else
            {
                if (tankDrive.PickupCheck == true)
                {
                    tankDrive.pickupRicochetPickup = true;
                    Destroy(collision.gameObject);

                }
            }
        }
        if (collision.gameObject.tag == "RocketPower")
        {
            if (forplayer == false)
            {
                tankfsm.RocketPickedUp += 1;
                tankfsm.HasRocket = true;
                tankfsm.RocketPowerUpEnd();
                Destroy(collision.gameObject);
            }
            else
            {
                if (tankDrive.PickupCheck == true)
                {
                    tankDrive.pickupRocketpowerup = true;
                    Destroy(collision.gameObject);
                }

            }
        }

        if (collision.gameObject.tag == "Rapid_Fire")
        {
            if (forplayer == false)
            {
                tankfsm.RapidfirePickedUp += 1;
                tankfsm.HasRapiedfire = true;
                tankfsm.RapiedfireEnd();
                Destroy(collision.gameObject);
            }
            else
            {
                if (tankDrive.PickupCheck == true)
                {
                    tankDrive.pickRapid_Fire = true;
                    Destroy(collision.gameObject);
                }

            }
        }
        if (collision.gameObject.GetComponent<Flag>())
        {
            if (forplayer == false)
            {
                if (tankfsm.HasFlag == false)
                {
                    Debug.Log("flag");
                    Animator animatior = tankfsm.GetComponent<Animator>();
                    animatior.SetBool("HasFlag", true);
                    collision.gameObject.transform.parent = tankfsm.transform;
                    collision.gameObject.transform.position = tankfsm.FlagStoreLocation.transform.position;
                    FlagMaster flagMaster = FindObjectOfType<FlagMaster>();
                    if (tankfsm.Enemytag == "Team1")
                    {
                        flagMaster.SetFlagToTeam2();
                    }
                    if (tankfsm.Enemytag == "Team2")
                    {
                        flagMaster.SetFlagToTeam1();
                    }
                    flagMaster.FlagCarier = tankfsm.gameObject;
                    tankfsm.HasFlag = true;
                }
            }
            else
            {
                if (tankDrive.HasFlag == false)
              { 
                tankDrive.HasFlag = true;
                collision.gameObject.transform.parent = tankDrive.transform;
                collision.gameObject.transform.position = tankDrive.FlagStoreLocation.transform.position;
                FlagMaster flagMaster = FindObjectOfType<FlagMaster>();
                if (tankDrive.Enemytag == "Team1")
                {
                   flagMaster.SetFlagToTeam2();
                }
                if (tankDrive.Enemytag == "Team2")
                {
                    flagMaster.SetFlagToTeam1();
                }
                    flagMaster.FlagCarier = tankDrive.gameObject;
                    tankDrive.HasFlag = true;
                }
            }
        }
        if (collision.gameObject.tag =="MineGlobel")
        {

            MinPerToTake = collision.gameObject.GetComponent<Mineteam>().MinPerToTake;
            MaxPerToTake = collision.gameObject.GetComponent<Mineteam>().MaxPerToTake;
            damage = Random.Range(MinPerToTake, MaxPerToTake);

            if (forplayer == false)
            {
                tankfsm.DamageBYDoneMineGlobal = +damage;
                tankfsm.GlobelMineHits = +1;
                dealdamageto();
            }
            else
            {
                tankDrive.DamageBYMineGlobal = +damage;
                tankDrive.GlobelMineHits = +1;
                dealdamageto();
            }
        }
        if (collision.gameObject == tankfsm.EnemyFlagZone )
        {
            if (forplayer == false)
            {
                Animator animatior = tankfsm.GetComponent<Animator>();
                animatior.SetBool("Goal", true);
                //tankfsm.FlagCaptured += 1;
            }
            else
            {
                Flag Flag = FindObjectOfType<Flag>();
                Flag.MoveToSpawn();
                tankDrive.FlagScore();
            }
        }
       // Debug.Log(collision.collider.name);
    }
    void dealdamageto()
    {
        if (forplayer == true)
        {
            tankDrive.GetComponent<TankDrive>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);
            Debug.Log(test);

        }
        else
        {
            tankfsm.GetComponent<Tankfsm>().DealDamage(damage, damgeTypes, MinPerToTake, MaxPerToTake);

        }
    }
    void lasthit()
    {
        if(forplayer == true)
        {
          //  tankDrive.GetComponent<TankDrive>().LastHitby = CollsionSpawner.gameObject.name;
        }
        else
        {
          //  tankfsm.GetComponent<Tankfsm>().LastHitby = CollsionSpawner.gameObject.name;
        }
    }
}
