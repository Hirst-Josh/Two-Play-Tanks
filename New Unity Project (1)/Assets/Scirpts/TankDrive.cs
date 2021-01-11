using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.VFX;
using XboxCtrlrInput;

public class TankDrive : MonoBehaviour
 {
     public float turnSpeed = 50f;
     float m_Speed;
     private Rigidbody m_Rigidbody;
    public int DamageDone;
    public int DamageByRockets;
    public int DamageByRichet;
    public int DamgeByRocketRic;
    public int DamageByMissle;
    public int DamageBYMissleRic;
    public int DamgeByMineTeam;
    public int DamageBYMineGlobal;
    public int RichetsShellhit;
    public int ShotsHits;
    public string LastHitby;
    public int RocketsFiredHit;
    public int MineTeamHit;
    public int MissleRicHit;
    public int MissleHit;
    public int Heal;
    AudioSource audioo;
    public float healthpacktoadd;
    public int HealthPacksUsed;
    public bool PickUpRicochet;
    public int RicohetPackpickup;
    public int RocketPickedUp;
    public int Rapid_FirePickedup;
    public bool HasRapid_Fire;
    public bool HasRocket;
    public int GlobelMineHits;
    public int Kills;
    public int RocketRicHit;
    public int HealthDamage;
    public int HealthDamageByRocketRic;
    public int HealthDamageByMissle;
    public int HealthDamageByMissleRic;
    public int HealthDamageByMineTeam;
    public int HealthDamageByRockets;
    public int HealthDamageByRichet;
    public int HealthDamageByShells;
    public int DamageDoneByShell;
    public GameObject killedby;
    public int ShellsHit;
    public bool HasFlag;
    public GameObject FlagStoreLocation;
    public GameObject FlagDeathDrop;
    public int FlagCaptured;
    public LayerMask targetmask;
    public LayerMask obstamcelmask;
    public List<Transform> VisableTargets = new List<Transform>();
    bool HealthPack; 
    bool RicochetPickup;
    bool Rocketpowerup;
    bool Rapid_Fireup;
    public bool pickupHealthPack;
    public bool pickupRicochetPickup;
    public bool pickupRocketpowerup;
    public bool pickRapid_Fire;
    GameObject temphealh;
    GameObject tempRico;
    GameObject tempPower;
    public float viewradius;
    [Range(0, 360)]
    public float viewangle;
    public bool shooting;
    public bool shootingmissle;
    public bool shootingrico;
    public bool Grainammo;
    public bool isrepair;
    public bool canrepair;
    public float DisToSpawn;
    bool repair;
    public GameObject spawn;
    public Text HealthText;
    public Text repairtext;
    public GameObject flag;
    public int ZonesPoint;
    public Scrollbar scrollbar;
    [SerializeField] private DamageResistance damageresis;
    [SerializeField] public float healh;
    public float maxhelath;
    MineMap mineMap;
    public string Enemytag;
    string spawntime;
    string deathtime;
    public VisualEffect EngineEffect;
    public AudioSource Engine;
    public Flag Flag;
    public float FlagFromEnemyZone;
    public GameObject EnemyFlagZone;
    private void Start()
    {
        m_Speed = 10.0f;
        maxhelath = healh;
        spawntime = System.DateTime.UtcNow.ToString();
        Engine.Play();
    }

    private void Awake()
    {
        InvokeRepeating("FindVisableTargets", 0.0f, 0.5f);
        InvokeRepeating("TextUpdate", 0.0f, 0.1f);
        mineMap = FindObjectOfType<MineMap>();
        mineMap.player = gameObject;
        mineMap.player_Alive = true;
        EnemyFlagZone = GameObject.Find("Team2 FlagPoint");
        Flag = FindObjectOfType<Flag>();
    }

    private void TextUpdate()
    {
        HealthText.text = healh.ToString();
        //repairtext.text = DisToSpawn.ToString();

        scrollbar.size = healh / maxhelath;

    }

    void DeadTexturesSwap()
    {
        MaterialSwap[] children = GetComponentsInChildren<MaterialSwap>();
        foreach (MaterialSwap target in children)
        {
            target.Swap();
        }
    }

    public void DealDamage(int damage, DamgeTypes damgeTypes, int MinPerToTake, int MaxPerToTake)
    {
        healh -= damage;
        if (healh <= 0)
        {
            deathtime = System.DateTime.UtcNow.ToString();
            GameObject Camerac = GameObject.Find("Camera");
            SmoothFollow smoothFollow = FindObjectOfType<SmoothFollow>();
            smoothFollow.Enemykillscount += 1;
            EngineEffect.Stop();
            Engine.Stop();
            DeadTexturesSwap();
            DropFlagDead();
            FindObjectOfType<Score_Master>().losted += 1;
            FindObjectOfType<Score_Master>().newscore();
            ///smoothFollow.playermenu.SetActive(true);
            Camerac.GetComponent<SmoothFollow>().isMoveToSpawnActive = true;
            // Camerac.GetComponent<SmoothFollow>().spawed = false; controlled by camera now, cmera will slowey move back to spawn now;
            //Camerac.GetComponent<SmoothFollow>().image.transform.position = Camerac.GetComponent<SmoothFollow>().imagespawned;
            
            CSVManager.PlayerAppendToReport(GetPlayerReportLine());
            Destroy(gameObject, 5.0f);
        }
    }

    public void HealthPackHeal()
    {
        healh += healthpacktoadd;
        HealthPacksUsed += 1;
    }

    string[] GetPlayerReportLine()
    {
        string[] returnable = new string[25];
        returnable[0] = DamageDone.ToString();
        returnable[1] = DamageByRockets.ToString();
        returnable[2] = DamageByRichet.ToString();
        returnable[3] = DamgeByRocketRic.ToString();
        returnable[4] = DamageByMissle.ToString();
        returnable[5] = DamageBYMissleRic.ToString();
        returnable[6] = DamgeByMineTeam.ToString();
        returnable[7] = DamageBYMineGlobal.ToString();
        returnable[8] = RichetsShellhit.ToString();
        returnable[9] = ShotsHits.ToString();
        returnable[10] = LastHitby.ToString();
        returnable[11] = RocketsFiredHit.ToString();
        returnable[12] = MineTeamHit.ToString();
        returnable[13] = MissleRicHit.ToString();
        returnable[14] = MissleHit.ToString();
        returnable[15] = Kills.ToString();
        returnable[16] = HealthDamage.ToString();
        returnable[17] = HealthDamageByMineTeam.ToString();
        returnable[18] = HealthDamageByMissle.ToString();
        returnable[19] = HealthDamageByMissleRic.ToString();
        returnable[19] = HealthDamageByRichet.ToString();
        returnable[20] = HealthDamageByRocketRic.ToString();
        returnable[21] = HealthDamageByRockets.ToString();
        returnable[22] = HealthDamageByShells.ToString();
        returnable[23] = spawntime.ToString();
        returnable[24] = deathtime.ToString();
        return returnable;
    }

    void FindVisableTargets()
    {
        DisToSpawn = Vector3.Distance(spawn.transform.position, transform.position);
        if (DisToSpawn <= 10.0f)
        {
            repairtext.text = "true";
        }
        else
        {
            repairtext.text = "false";
        }
        if(DisToSpawn <=  10.0f  && isrepair == true)
        {
            //repair = true;
            InvokeRepeating("heal", 0.0f, 1.0f);
        }
        else
        {
            // repair = false;
            // do void invokeing evrey second, check if reapir true,if true heal helath;
            StopCoroutine("heal");
        }

        if (DisToSpawn <= 10.0f && Grainammo == true)
        {
  
        }
        else
        {
           
        }

        
        Collider[] targetsinviewradius = Physics.OverlapSphere(transform.position, viewradius, targetmask);

           for (int i = 0; i < targetsinviewradius.Length; i++)
           {
              Transform target = targetsinviewradius[i].transform;
              Vector3 dirToTarget = (transform.position - transform.position).normalized;
               if (Vector3.Angle(transform.forward, dirToTarget) < viewangle / 2)
               {
                float disttotaget = Vector3.Distance(transform.position, transform.position);

                 if (!Physics.Raycast(transform.position, dirToTarget, disttotaget, obstamcelmask))
                 {
                    VisableTargets.Add(target);

                    //if (target.gameObject.tag == "Healthpack" || tag == "RicochetPickup" || tag == "RocketPower")
                    // {
                    if (target.gameObject.tag == "Healthpack")
                    {
                        HealthPack = true;
                        temphealh = target.gameObject;
                    }
                    

                    if (target.gameObject.tag == "RicochetPickup")
                    {
                        RicochetPickup = false;
                        tempRico = target.gameObject;
                    }
                    
                    if (target.gameObject.tag == "RocketPower")
                    {
                        Rocketpowerup = true;
                        tempPower = target.gameObject;
                    }
                    if (target.gameObject.tag == "Rapid_Fire")
                    {
                        Rapid_Fireup = true;
                        tempPower = target.gameObject;
                    }
                    

                 }
               }
           }
    }

    public Vector3 DirFromangle(float angleInDegree, bool angleisglobel)
    {
        if (!angleisglobel)
        {
            angleInDegree += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }

    public bool PickupCheck;
   

    void flagDrop()
    {
        if (HasFlag == true)
        {
            flag.transform.position = FlagDeathDrop.transform.position;
            flag.transform.parent = null;
        }
    }

    void heal()
    {
        healh += Heal;
        if (healh > maxhelath)
        {
            healh = maxhelath;
            Debug.Log("heal");
        }
    }



    public void playsound()
    {
        audioo = GetComponent<AudioSource>();
        audioo.Play();
    }


    public void DropFlagDead()
    {
        if (flag != null)
        {
            Flag.transform.position = FlagDeathDrop.transform.position;
            Flag.transform.parent = null;
            FlagMaster flagMaster = FindObjectOfType<FlagMaster>();
            flagMaster.Team1HasFlag = false;
            flagMaster.Team2HasFlag = false;
            flagMaster.flagFree = true;
        }
    }

    public void FlagScore()
    {
        FlagCaptured += 1;
        FindObjectOfType<FlagMaster>().Team1Score += 1;
        
    }
 

}