using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.VFX;
using System.IO;

public class Tankfsm : MonoBehaviour
{
    // General state machine variables
    public GameObject Target;
    public GameObject spawn;
    GameObject Healthpack;
    GameObject RicochetPickup;
    GameObject battleMole;
    public GameObject fleetarget;
    public float finalValue;
    public Transform Targett;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    public bool ispatrolpath;
    private float maxDistanceToCheck = 10.0f;
    private float currentDistance;
    private float DistanceFromSpawn;
    private Vector3 checkDirection;
    public float multiplyBy;
    private float spaceTimer;
    int Feecounter;
    public bool PickUpRicochet;
    // Patrol state variables
    GameObject RocketPowerUpGet;
    public NavMeshAgent navMeshAgent;
    public bool shootstate;
    bool isdestroyed;
    //var for invesi
    private float timer = 0;
    public int RichetsShellhit;
    public int RocketRicHit;
    public int MissleHit;
    public int MissleRicHit;
    public string LastHitby;
    public string Enemytag;
    public string Spawntag;
    // health syterm dont mess or face crashing unity 
    [SerializeField] private DamageResistance damageresis;
    [SerializeField] public float healh;
    public float healthpacktoadd;
    private float maxhealth;
    private GameObject spawnobject;
    private int currentTarget;
    private int currentTarget2;
    private int currentTarget3;
    public float distanceFromTarget;
    public float distanceFromTarget2;
    public float distanceFromTarget3;
    public GameObject[] waypoints;
    public GameObject[] waypoints2;
    public GameObject[] waypoints3;
    // public GameObject[] fleeinfo;
    public List<GameObject> fleeinfo = new List<GameObject>();
    public float EnemyDistanceRun;
    public bool isflee;
    float fleechecked;
    public TankStatus tankStatus;
    public float MinSafeHealth;
    public float avoidHealth;
    public float fleefast;
    public float fleesafe;
    bool fleesee;
    public float viewradius;
    [Range(0, 360)]
    public float viewangle;
    public int GlobelMineHits;
    public int MineTeamHit;
    public LayerMask targetmask;
    public LayerMask obstamcelmask;
    float DistanceFromMineDrop;
    [HideInInspector]
    public List<Transform> VisableTargets = new List<Transform>();
    public GameObject Minedrop;
    public bool incombat;
    public Vector3 predict;
    public int Heal;
    public int HealthPacksUsed;
    public int RicohetPackpickup;
    public int RocketPickedUp;
    public int RapidfirePickedUp;
    bool path1;
    bool path2;
    bool path3;
    int num;
    public bool HasRocket;
    public bool HasRapiedfire;
    public bool area1;
    public bool area2;
    public bool area3;
    public bool area4;
    public int Kills;
    public TankTag TankTag;
    public TankTypeName TankTypeNameString;
    private int patrol1;
    private int patrolno2;
    private int patrolno3;
    public int RocketsFiredHit;
    AudioSource audioData;
    public bool Middle;
    public bool Heavy;
    public bool Light;
    public bool MG;
    public bool Missle;
    public bool Mine;
    public bool MBT;
    public bool Deathis;
    public int DamageDone;
    public int HealthDamage;
    public int ShotsHits;
    private int PointsPassed;
    public GameObject manger;
    public int DamageDoneByRockets;
    public int HealthDamageByRockets;
    public int DamageDoneByRichet;
    public int HealthDamageByRichet;
    public int DamageDoneByRocketRic;
    public int HealthDamageByRocketRic;
    public int DamageDoneByMissle;
    public int HealthDamageByMissle;
    public int DamageDoneBYMissleRic;
    public int HealthDamageByMissleRic;
    public int DamgeByDoneMineTeam;
    public int HealthDamageByMineTeam;
    public int DamageBYDoneMineGlobal;
    public int DamageDoneByShell;
    public int HealthDamageByShells;
    public int RandomMineArea;
    public int SearchArea;
    public int ShellsHit;
    public int ShotsFired;
    public Vector3 MineLocation1;
    public Rigidbody Team1Mine;
    public Rigidbody Team2Mine;
    public Transform MineDrop;
    public bool MineDrop1;
    private GameObject Mine1Ref;
    public Vector3 MineLocation2;
    public bool MineDrop2;
    private GameObject Mine2Ref;
    public Vector3 MineLocation3;
    public bool MineDrop3;
    private GameObject Mine3Ref;
    public Vector3 MineLocation4;
    public bool MineDrop4;
    private GameObject Mine4Ref;
    public Vector3 MineLocation5;
    public bool MineDrop5;
    private GameObject Mine5Ref;
    public Vector3 MineLocation6;
    public bool MineDrop6;
    private GameObject Mine6Ref;
    public GameObject Empty;
    public AnimationCurve Probabiility;
    public float RandomNumber;
    public float GenRandomNumber;
    int MinesDropped;
    public bool MineSystermActive;
    Vector3 TargetlastPos;
    public Vector3 BmoleTargetLastPostion;
    Vector3 SearchPoint1;
    Vector3 SearchPoint2;
    Vector3 SearchPoint3;
    private GameObject SearchPointRef;
    private GameObject SearchPointRef2;
    private GameObject SearchPointRef3;
    public GameObject killedby;
    private string spawntime;
    public GameObject Flag;
    public GameObject FlagZone;
    public GameObject EnemyFlagZone;
    public bool IsgamemadeFlag;
    private float FlagFromZone;
    private float FlagFromEnemyZone;
    private float DistanceFromFlag;
    private float DistanceToSearchPoint;
    public bool No1;
    public bool No2;
    public bool No3;
    private Vector3 ProtectFlagLoc;
    public GameObject FlagCarrier;
    public bool HasFlag;
    public bool GetFlag;
    public GameObject FlagStoreLocation;
    public GameObject FlagDeathDrop;
    public int FlagCaptured;
    public string Gamemode;
    public string Map;
    public GameObject ZoneA;
    public GameObject ZoneB;
    private float ZoneADis;
    private float ZoneBDis;
    public int ZonesPoint;
    public VisualEffect EngineEffect;
    public AudioSource Engine;

     GameObject RapidfireUpGet;

    private void Start()
    {
        // InvokeRepeating("FindClosestEnemy", 0.0f, 0.3f);
        InvokeRepeating("CombatActive", 0.0f, 0.3f);
        InvokeRepeating("FindVisableTargets", 0.0f, 0.3f);
        if (TankTag == TankTag.Mine)
        {
            InvokeRepeating("UpdateDistanceFromMineDrop", 0.0f, 0.3f);
        }
      //  InvokeRepeating("clear", 0.0f, 30.0f);
        // InvokeRepeating("Sight", 0.0f, 0.1f);
        if (Enemytag == "Team2")
        {
            InvokeRepeating("FindClosestTeam2", 0.0f, 1.5f);
          //  Debug.Log("ishgooahg");
        }
        if (Enemytag == "Team1")
        {
            InvokeRepeating("FindClosestTeam1", 0.0f, 1.5f);

        }


    }
    private void Awake()
    {
        Target = GameObject.FindWithTag(Enemytag);
        Targett = Target.transform;
        spawn = GameObject.FindWithTag(Spawntag);
        animator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        maxhealth = healh;
        spawnobject = GameObject.FindWithTag(Spawntag);
        waypoints = spawnobject.GetComponent<respawn>().waypoints;
        waypoints2 = spawnobject.GetComponent<respawn>().waypoints2;
        waypoints3 = spawnobject.GetComponent<respawn>().waypoints3;
        Feecounter = 0;
        PointsPassed = 0;
        ShotsHits = 0;
        DamageDone = 0;
        spaceTimer = 5f;
        Deathis = false;
        fleesee = false;
        currentTarget = 0;
        currentTarget2 = 0;
        currentTarget3 = 0;
        path1 = true;
        animator.SetBool("path1", true);
        num = 5;
        navMeshAgent.SetDestination(waypoints[currentTarget].transform.position);
        Patrolpath();
        patrol1 = 0;
        RocketPickedUp = 0;
        patrolno2 = 0;
        patrolno3 = 0;
        RichetsShellhit = 0;
        HealthPacksUsed = 0;
        RicohetPackpickup = 0;
        RocketsFiredHit = 0;
        battleMole = GameObject.FindGameObjectWithTag("Bmole");
        spawntime = System.DateTime.UtcNow.ToString();
        SearchArea = 4;
        Engine.Play();
        
}

    private void Update()
    {
        if (path1 == true)
        {
            distanceFromTarget = Vector3.Distance(waypoints[currentTarget].transform.position, transform.position);
            animator.SetFloat("DistanceFromWaypoint", distanceFromTarget);
        }
        if (path2 == true)
        {
            distanceFromTarget2 = Vector3.Distance(waypoints2[currentTarget2].transform.position, transform.position);
            animator.SetFloat("DistanceFromWaypoint", distanceFromTarget2);
        }

        if (path3 == true)
        {
            distanceFromTarget3 = Vector3.Distance(waypoints3[currentTarget3].transform.position, transform.position);
            animator.SetFloat("DistanceFromWaypoint", distanceFromTarget3);
        }
    }
    
    void DeadTexturesSwap()
    {
        MaterialSwap[] children = GetComponentsInChildren<MaterialSwap>();
        foreach(MaterialSwap target in children)
        {
            target.Swap();
        }
    }

    IEnumerator Kill()
    {
        while (true)

        {
            // Debug.Log("kill");
            SmoothFollow smoothFollow = FindObjectOfType<SmoothFollow>();
            tankStatus = TankStatus.dead;
            EngineEffect.Stop();
            DeadTexturesSwap();
            Engine.Stop();
            if (gameObject.tag == "Team2")
            {
                Destroy(GetComponent<Team2Tracker>());
                navMeshAgent.SetDestination(gameObject.transform.position);
                navMeshAgent.isStopped = true;
            }
            if (gameObject.tag == "Team1")
            {
                Destroy(GetComponent<Team1Tracker>());
                navMeshAgent.SetDestination(gameObject.transform.position);
                navMeshAgent.isStopped = true;
            }
            //Battle_Mole_Trigger();
            //Debug.Log(gameObject.name + "bmole t");
       

            if (killedby.GetComponent<Tankfsm>() == true)
            {
                killedby.GetComponent<Tankfsm>().Kills += 1;
            }
            else
            {
                killedby.GetComponent<TankDrive>().Kills += 1;
            }

            if (Enemytag == "Team1")
            {
                FindObjectOfType<Score_Master>().killed += 1;
            }
            if (Enemytag == "Team2")
            {
                FindObjectOfType<Score_Master>().losted += 1;
            }
            FindObjectOfType<Score_Master>().newscore();
            yield return new WaitForSeconds(9);
            Report();
            yield return new WaitForSeconds(2);
            Destroy(gameObject);

        }
    }


    void FindVisableTargets()
    {
        animator.SetBool("shootstate", shootstate);
        Targett = Target.transform;
        animator.SetFloat("DistancefromTarget", currentDistance);
        currentDistance = Vector3.Distance(Target.transform.position, transform.position);
        animator.SetFloat("DistanceFromSpawn", DistanceFromSpawn);
        DistanceFromSpawn = Vector3.Distance(spawn.transform.position, transform.position);
        VisableTargets.Clear();
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
                            Healthpack = target.gameObject;
                            animator.SetBool("SeeHealth", true);
                        }

                        else if (target.gameObject.tag == "RicochetPickup")
                        {
                            RicochetPickup = target.gameObject;
                            animator.SetBool("Ricochet", true);

                        }
                        else if (target.gameObject.tag == "Rapid_Fire")
                        {
                            RapidfireUpGet = target.gameObject;
                            animator.SetBool("Rapidfire", true);
                        }

                        else if (target.gameObject.tag == "RocketPower")
                        {
                          RocketPowerUpGet = target.gameObject;
                          animator.SetBool("Rocket", true);
                        }


                    if (target.gameObject == Target)
                        {
                        animator.SetBool("CanSeeTarget", true);
                        }
                        else if(target.gameObject != Target)
                        {
                        animator.SetBool("CanSeeTarget", false);
                        }
                  //  }
                   // else
                   // {
                     //   animator.SetBool("Ricochet", false);
                     //   animator.SetBool("SeeHealth", false);
                     //   animator.SetBool("Rocket", false);
                 // }



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
    public void SetNextPoint()
    {
        currentTarget = (currentTarget + 1) % waypoints.Length;
        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].transform.position, transform.position);
        navMeshAgent.SetDestination(waypoints[currentTarget].transform.position);
        path1 = true;

        PointsPassed += 1;
        patrol1 += 1;
    }

    public void SetNextPointPath2()
    {
        currentTarget2 = (currentTarget2 + 1) % waypoints2.Length;
        path2 = true;
        distanceFromTarget = Vector3.Distance(waypoints2[currentTarget2].transform.position, transform.position);
        navMeshAgent.SetDestination(waypoints2[currentTarget2].transform.position);

        PointsPassed += 1;
        patrolno2 += 1;
    }
    public void SetNextPointPath3()
    {
        currentTarget3 = (currentTarget3 + 1) % waypoints3.Length;
        path3 = true;
        distanceFromTarget = Vector3.Distance(waypoints3[currentTarget3].transform.position, transform.position);
        navMeshAgent.SetDestination(waypoints3[currentTarget3].transform.position);

        PointsPassed += 1;
        patrolno3 += 1;

    }
    public void ChaseTarget()
    {
        navMeshAgent.destination = Target.transform.position;
        StartCoroutine("ForChaseTarget");
    }

    IEnumerator ForChaseTarget()
    {
        while (true)
        {
            //updates the destination, testing should it does not do live updates to the target a postion, this would fix that
            navMeshAgent.destination = Target.transform.position;
            yield return new WaitForSeconds(1);
        }
    }

    public void Battelinfo()
    {
        StartCoroutine("Battle");
    }

    public void BattleInfoEnd()
    {
        StopCoroutine("Battle");
    }
    public IEnumerator Battle()
    {
        while (true)
        {
            EnemyPostion();
            if (Target.gameObject.tag == Enemytag)
            {
              //  Debug.Log("tank spotted");
                if (Target.GetComponent<Tankfsm>() == true)
                {
                  //  Debug.Log("tank true");
                    Tankfsm check = Target.GetComponent<Tankfsm>();
                    if (check.TankTag == TankTag.Medium)
                    {
                        Middle = true;
                    }
                    else
                    {
                        Middle = false;
                    }
                    if (check.TankTag == TankTag.Heavy)
                    {
                        Heavy = true;
                    }
                    else
                    {
                        Heavy = false;
                    }
                    if (check.TankTag == TankTag.Light)
                    {
                        Light = true;
                    }
                    else
                    {
                        Light = false;
                    }
                    if (check.TankTag == TankTag.MG)
                    {
                        MG = true;
                    }
                    else
                    {
                        MG = false;
                    }
                    if (check.TankTag == TankTag.Missle)
                    {
                        Missle = true;
                    }
                    else
                    {
                        Missle = false;
                    }
                    if (check.TankTag == TankTag.Mine)
                    {
                        Mine = true;
                    }
                    else
                    {
                        Mine = false;
                    }
                    if (check.TankTag == TankTag.MBT)
                    {
                        MBT = true;
                    }

                    else
                    {
                        MBT = false;
                    }
                }

                else
                {
                    Middle = true;
                }
                yield return new WaitForSeconds(1);
            }
            
        }
    }

    public void EndChaseTarget()
    {
        StopCoroutine("ForChaseTarget");
    }
    public void ShootTarget()
    {
        navMeshAgent.SetDestination(gameObject.transform.position);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
    }
    public void shootend()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
    }
    public void patrol()
    {
        navMeshAgent.SetDestination(waypoints[currentTarget].transform. position);
    }
    public void patrol2()
    {
        navMeshAgent.SetDestination(waypoints2[currentTarget2].transform. position);
    }
    public void patrol3()
    {
        navMeshAgent.SetDestination(waypoints3[currentTarget3].transform.position);
    }
    public void Healthpackget()
    {
        navMeshAgent.SetDestination(Healthpack.transform.position);
    }
    public void Healthpackend()
    {
        if(Healthpack == null) { animator.SetBool("SeeHealth", false); }
        else { navMeshAgent.SetDestination(Healthpack.transform.position); }
    }
    public void RicochetPowerUp()
    {
        navMeshAgent.SetDestination(RicochetPickup.transform.position);
    }
    public void RicohetPowerupEnd()
    {
        if (RicochetPickup == null) { animator.SetBool("Ricochet", false); }
        else { navMeshAgent.SetDestination(RicochetPickup.transform.position); }
    }
    public void RocketPowerUp()
    {
        navMeshAgent.SetDestination(RocketPowerUpGet.transform.position);
    }
    public void RocketPowerUpEnd()
    {
        if (RocketPowerUpGet == null) { animator.SetBool("Rocket", false); }
        else { navMeshAgent.SetDestination(RocketPowerUpGet.transform.position); }
    }
    public void RapiedfireGet()
    {
        navMeshAgent.SetDestination(RapidfireUpGet.transform.position);
    }
    public void RapiedfireEnd()
    {
        if (RapidfireUpGet == null) { animator.SetBool("Rapidfire", false); }
        else { navMeshAgent.SetDestination(RapidfireUpGet.transform.position); }
    }

    public void fleestate()
    {
        StartCoroutine("flee");
    }

    IEnumerator flee()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < EnemyDistanceRun)
            {
                Vector3 to = transform.position - Target.transform.position;
                Vector3 newpos = transform.position + to;
                navMeshAgent.SetDestination(newpos);
                yield return new WaitForSeconds(1);

            }
           // if (distance > EnemyDistanceRun)
           // {
           //     {

              //      if (Enemytag == "Team2")
               //     {
                        //fleeinfo.AddRange(GameObject.FindGameObjectsWithTag("Team1fleePoints"));
                //    }
                 //   if (Enemytag == "Team1")
                 //   {
                       // fleeinfo.AddRange(GameObject.FindGameObjectsWithTag("Team2fleePoints"));
                 //   }

                 //   Invoke("findflee", 0.1f);
                 //   StopCoroutine("flee");

               // }
           // }


        }
    }
    public void fleeend()
    {
        StopCoroutine("flee");
    }

    public void DealDamage(int damage, DamgeTypes damgeTypes, int MinPerToTake, int MaxPerToTake)
    {
        healh -= damage;
       // Debug.Log(damage);
        animator.SetFloat("aihealth", healh);
        //Debug.Log(healh + gameObject.name);
        if (healh <= 0)
        {
            Deathis = true;
            animator.SetBool("Deathis", true);
            
            

        }
        else
        {
            
        }

        finalValue = (healh / maxhealth) * 100;

        animator.SetFloat("finalValue", finalValue);
    }


    string[] GetReportLine()
    {
        string[] returnable = new string[43];
        returnable[0] = tag.ToString();
        returnable[1] = gameObject.name.ToString();
        returnable[2] = healh.ToString();
        returnable[3] = DamageDone.ToString();
        returnable[4] = ShotsHits.ToString();
        returnable[5] = PointsPassed.ToString();
        returnable[6] = Feecounter.ToString();
        returnable[7] = patrol1.ToString();
        returnable[8] = patrolno2.ToString();
        returnable[9] = patrolno3.ToString();
        returnable[10] = TankTag.ToString();
        returnable[11] = TankTypeNameString.ToString();
        returnable[12] = RicohetPackpickup.ToString();
        returnable[13] = HealthPacksUsed.ToString();
        returnable[14] = RichetsShellhit.ToString();
        returnable[15] = RocketPickedUp.ToString();
        returnable[16] = RocketsFiredHit.ToString();
        returnable[17] = DamageDoneByRichet.ToString();
        returnable[18] = DamageDoneByRockets.ToString();
        returnable[19] = DamageDoneByMissle.ToString();
        returnable[20] = MissleHit.ToString();
        returnable[21] = Kills.ToString();
        returnable[22] = LastHitby.ToString();
        returnable[23] = MissleRicHit.ToString();
        returnable[24] = DamageDoneBYMissleRic.ToString();
        returnable[25] = DamageBYDoneMineGlobal.ToString();
        returnable[26] = HealthDamage.ToString();
        returnable[27] = HealthDamageByMineTeam.ToString();
        returnable[28] = HealthDamageByMissle.ToString();
        returnable[29] = HealthDamageByMissleRic.ToString();
        returnable[30] = HealthDamageByRichet.ToString();
        returnable[31] = HealthDamageByRocketRic.ToString();
        returnable[32] = HealthDamageByRockets.ToString();
        returnable[33] = DamageDoneByShell.ToString();
        returnable[34] = HealthDamageByShells.ToString();
        returnable[35] = ShellsHit.ToString();
        returnable[36] = spawntime;
        returnable[37] = ShotsFired.ToString();
        returnable[38] = Gamemode.ToString();
        returnable[39] = Map.ToString();
        returnable[40] = FlagCaptured.ToString();
        returnable[41] = HasFlag.ToString();
        returnable[42] = ZonesPoint.ToString();
        return returnable;
    }


    void Report()
    {
        CSVManager.AppendToReport(GetReportLine());
        if (TankTypeNameString == TankTypeName.Sherman)
        {
            CSVManager.AppendToReportM4(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.SMK)
        {
            CSVManager.AppendToReportSMK(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.T34)
        {
            CSVManager.AppendToReportT34(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.T72)
        {
            CSVManager.AppendToReportT72(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.tos1)
        {
            CSVManager.AppendToReportTOS1(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.Mine)
        {
            CSVManager.AppendToReportMine(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.tiger)
        {
            CSVManager.AppendToReportTiger(GetReportLine());
        }
        if (TankTypeNameString == TankTypeName.Panzer_II)
        {
            CSVManager.AppendToReportPanzerII(GetReportLine());
        }
    }



    public void shoot()
    {
        //SoundAssets.sound.PlaySfx(Shoot);
    }




    public Team1Tracker FindClosestTeam1()
    {


        Team1Tracker[] gos = FindObjectsOfType<Team1Tracker>();

        Team1Tracker closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Team1Tracker go in gos)
        {


            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Target = go.gameObject;
            }

            if (go.GetComponent<Tankfsm>() == true)
            {
                if (go.GetComponent<Tankfsm>().Deathis == true)
                {
                    gos = new Team1Tracker[0];
                    return null;
                }

            }
        }



        Targett = Target.transform;
        return closest;

    }

    public Team2Tracker FindClosestTeam2()
    {


        Team2Tracker[] gos = FindObjectsOfType<Team2Tracker>();

        Team2Tracker closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Team2Tracker go in gos)
        {


            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Target = go.gameObject;
            }

            if(go.GetComponent<Tankfsm>().Deathis == true)
            {
                gos = new Team2Tracker[0];
                return null;
            }
        }



        Targett = Target.transform;
        return closest;

    }

    public void Remove_flee()
    {
        fleeinfo.Remove(fleetarget);
        Invoke("findflee", 0.1f);
    }

    public void CombatActive()
    {
        if (healh > MinSafeHealth)
        {
            animator.SetBool("minsafe", true);
        }
        else
        {
            animator.SetBool("minsafe", false);
        }

        if (healh > avoidHealth)
        {
            animator.SetBool("avoidhealth", true);
        }
        else
        {
            animator.SetBool("avoidhealth", false);
        }
        if (healh > fleefast)
        {
            animator.SetBool("fleefast", true);
        }
        else
        {
            animator.SetBool("fleefast", false);
        }
        if (healh > fleesafe)
        {
            animator.SetBool("fleesafe", true);
        }
        else
        {
            animator.SetBool("fleesafe", false);
        }
        

    }

    public void Pursuit()
    {
        Vector3 halfway = Target.transform.position - transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 futurePostion = Target.transform.position + rb.velocity;
        navMeshAgent.SetDestination(futurePostion);
    }

    IEnumerator RestoreHealth()
    {
        while (healh < maxhealth)
        {
            Healthregen();
            yield return new WaitForSeconds(1);
        }
    }
    public void Healthregen()
    {
        healh += Heal;
        animator.SetFloat("aihealth", healh);
    }

    public void fleetpspawn()
    {
        navMeshAgent.SetDestination(spawn.transform.position);
    }

    public void fleespawninfo()
    {
    }

    public void StartHeal()
    {
        Feecounter += 1;
        StartCoroutine("RestoreHealth");
        navMeshAgent.SetDestination(gameObject.transform.position);
        //gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }
    public void StopHeal()
    {
        StopCoroutine("RestoreHealth");
       // gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }
    public void HealthPackHeal()
    {
        healh += healthpacktoadd;
        animator.SetFloat("aihealth", healh);
    }

    public void Patrolpath()
    {
        int num = Random.Range(0, 4);
        //Debug.Log(num);
        if (num == 1)
        {
            path1 = true;
            path2 = false;
            path3 = false;
            animator.SetBool("path1", true);
            animator.SetBool("path2", false);
            animator.SetBool("path3", false);
            Debug.Log("1");
        }
        if (num == 2)
        {
            path3 = false;
            path2 = true;
            path1 = false;
            animator.SetBool("path1", false);
            animator.SetBool("path2", true);
            animator.SetBool("path3", false);
            Debug.Log("2");
        }
        if (num == 3)
        {
            path3 = true;
            path2 = false;
            path1 = false;
            animator.SetBool("path1", false);
            animator.SetBool("path2", false);
            animator.SetBool("path3", true);
            Debug.Log("3");
        }

    }


    public void areapatrol()
    {

    }

    //public void patolpicker()
    //  {

    //    }

    public void Patroltrigger()
    {

        if (num == 0)
        {
            Patrolpath();
            num = Random.Range(5, 7);
            ispatrolpath = true;
            animator.SetBool("ispatrolpath", true);

        }
        else
        {
            num -= 1;
            ispatrolpath = false;
            animator.SetBool("ispatrolpath", false);
        }

    }
    public void MineVoid()
    {
        Debug.Log("mine void");
        StartCoroutine(Minewait());
      //  StartCoroutine("UpdateMineDrop");
    }

    IEnumerator Minewait()
    {
        RandomNumber = Random.Range(20, 60);
        GenRandomNumber = Probabiility.Evaluate(RandomNumber);
        GenRandomNumber = Mathf.Round(GenRandomNumber);
        Debug.Log(GenRandomNumber);
        int wait_time = Random.Range(0, 25);
        yield return new WaitForSeconds(RandomNumber);

        MineLocation1 = Random.insideUnitSphere * RandomMineArea;
        MineLocation1 = MineLocation1 + gameObject.transform.position;
        MineLocation1.y = gameObject.transform.position.y;
        if (Mine1Ref != null){ Destroy(Mine1Ref);}
        Mine1Ref = Instantiate(Empty, MineLocation1, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineLocation2 = Random.insideUnitSphere * RandomMineArea;
        MineLocation2 = MineLocation2 + gameObject.transform.position;
        MineLocation2.y = gameObject.transform.position.y;
        if (Mine2Ref != null) { Destroy(Mine2Ref); }
        Mine2Ref = Instantiate(Empty, MineLocation2, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineLocation3 = Random.insideUnitSphere * RandomMineArea;
        MineLocation3 = MineLocation3 + gameObject.transform.position;
        MineLocation3.y = gameObject.transform.position.y;
        if (Mine3Ref != null) { Destroy(Mine3Ref); }
        Mine3Ref = Instantiate(Empty, MineLocation3, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineLocation4 = Random.insideUnitSphere * RandomMineArea;
        MineLocation4 = MineLocation4 + gameObject.transform.position;
        MineLocation4.y = gameObject.transform.position.y;
        if (Mine4Ref != null) { Destroy(Mine4Ref); }
        Mine4Ref = Instantiate(Empty, MineLocation4, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineLocation5 = Random.insideUnitSphere * RandomMineArea;
        MineLocation5 = MineLocation5 + gameObject.transform.position;
        MineLocation5.y = gameObject.transform.position.y;
        if (Mine5Ref != null) { Destroy(Mine5Ref); }
        Mine5Ref = Instantiate(Empty, MineLocation5, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineLocation6 = Random.insideUnitSphere * RandomMineArea;
        MineLocation6 = MineLocation6 + gameObject.transform.position;
        MineLocation6.y = gameObject.transform.position.y;
        if (Mine6Ref != null) { Destroy(Mine6Ref); }
        Mine6Ref = Instantiate(Empty, MineLocation6, Quaternion.identity);
        // MineLocation1.y = Terrain.activeTerrain.SampleHeight(MineLocation1);

        MineSystermActive = true;
        animator.SetBool("Systerm", true);
        stopMineVoid();
    }

    public void stopMineVoid()
    {
        StopCoroutine(Minewait());
        InvokeRepeating("UpdateDistanceFromMineDrop", 0, 0.3F);
    }
    public void Stopmineupdateing()
    {
       CancelInvoke("UpdateDistanceFromMineDrop");
    }

    public void Mine1()
    {

        DistanceFromMineDrop = Vector3.Distance(Mine1Ref.transform.position,gameObject.transform.position);
        navMeshAgent.SetDestination(Mine1Ref.transform.position);
        MineDrop1 = true;
        animator.SetBool("Mine1", true);
    }
    public void Mine2()
    {
        DistanceFromMineDrop = Vector3.Distance(Mine2Ref.transform.position, gameObject.transform.position);
        navMeshAgent.SetDestination(Mine2Ref.transform.position);
        MineDrop2 = true;
        animator.SetBool("Mine2", true);
        animator.SetBool("Mine1", false);
    }
    public void Mine3()
    {
        DistanceFromMineDrop = Vector3.Distance(Mine3Ref.transform.position, gameObject.transform.position);
        navMeshAgent.SetDestination(Mine3Ref.transform.position);
        MineDrop3 = true;
        animator.SetBool("Mine3", true);
        animator.SetBool("Mine2", false);
        animator.SetBool("Mine1", false);
    }
    public void Mine4()
    {
        DistanceFromMineDrop = Vector3.Distance(Mine4Ref.transform.position, gameObject.transform.position);
        navMeshAgent.SetDestination(Mine4Ref.transform.position);
        MineDrop4 = true;
        animator.SetBool("Mine4", true);
        animator.SetBool("Mine3", false);
        animator.SetBool("Mine2", false);
        animator.SetBool("Mine1", false);

    }
    public void Mine5()
    {
        DistanceFromMineDrop = Vector3.Distance(Mine5Ref.transform.position, gameObject.transform.position);
        navMeshAgent.SetDestination(Mine5Ref.transform.position);
        MineDrop5 = true;
        animator.SetBool("Mine5", true);
        animator.SetBool("Mine4", false);
        animator.SetBool("Mine3", false);
        animator.SetBool("Mine2", false);
        animator.SetBool("Mine1", false);

    }
    public void Mine6()
    {
        DistanceFromMineDrop = Vector3.Distance(Mine6Ref.transform.position, gameObject.transform.position);
        navMeshAgent.SetDestination(Mine6Ref.transform.position);
        MineDrop6 = true;
        animator.SetBool("Mine6", true);
        animator.SetBool("Mine5", false);
        animator.SetBool("Mine4", false);
        animator.SetBool("Mine3", false);
        animator.SetBool("Mine2", false);
        animator.SetBool("Mine1", false);
    }
    public void UpdateDistanceFromMineDrop()
    {

        if (MineDrop1 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation1, gameObject.transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
           // Debug.Log(DistanceFromMineDrop);
        }
        if (MineDrop2 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation2, gameObject.transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
          //  Debug.Log(DistanceFromMineDrop);
        }
        if (MineDrop3 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation3, gameObject.transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
           // Debug.Log(DistanceFromMineDrop);
        }
        if (MineDrop4 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation4, gameObject.transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
           // Debug.Log(DistanceFromMineDrop);
        }
        if (MineDrop6 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation5, transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
           // Debug.Log(DistanceFromMineDrop);
        }
        if (MineDrop6 == true)
        {
            DistanceFromMineDrop = Vector3.Distance(MineLocation6, gameObject.transform.position);
            animator.SetFloat("Mine Drop", DistanceFromMineDrop);
           // Debug.Log(DistanceFromMineDrop);
        }
    }
    public void MineDropCounter()
    {
        if (Enemytag == "Team2")
        {
            Rigidbody rigidbody = Instantiate(Team1Mine, MineDrop.transform.position, Quaternion.Euler(-90, 0, 0)) as Rigidbody ;
        }
        if (Enemytag == "Team1")
        {

            Rigidbody rigidbody = Instantiate(Team2Mine, MineDrop.transform.position, Quaternion.Euler(-90, 0, 0)) as Rigidbody;

        }
            MinesDropped += 1;
    }
    public void CriticalDamage()
    {
        int Chance;
        Chance = Random.Range(0, 50);

        if(Chance > 45)
        {
            Battle_Mole_Trigger();

        }
        if (Chance > 35 &&  Chance < 45)
        {

        }
    }
    void Battle_Mole_Trigger()
    {
        BattleMole mole = battleMole.GetComponent<BattleMole>();
        if (gameObject.tag == "Team2")
        {
            Team2Tracker[] gos = FindObjectsOfType<Team2Tracker>();
            List<Team2Tracker> inventory;
            inventory = new List<Team2Tracker>(gos);
            inventory.Sort(delegate (Team2Tracker a, Team2Tracker b)
            {
                return Vector3.Distance(a.transform.position, TargetlastPos).CompareTo(Vector3.Distance(b.transform.position, TargetlastPos));
            }

           );
            Debug.Log(inventory);
            mole.Team2Contract = TargetlastPos;
            Team2Tracker game = inventory[1];
            mole.Team2closet1 = game.gameObject;
            Team2Tracker game2 = inventory[2];
            mole.Team2closet2 = game2.gameObject;
            Team2Tracker game3 = inventory[3];
            mole.Team2closet3 = game3.gameObject;
            mole.ToMoleTeam2();

            gos = new Team2Tracker[0];
        }
        if (gameObject.tag == "Team1")
        {
            Team1Tracker[] gos = FindObjectsOfType<Team1Tracker>();
            List<Team1Tracker> inventory;
           // foreach (Team1Tracker team1Tracker in gos)
           // {
               // if (Vector3.Distance(TargetlastPos , team1Tracker.transform.position)  < 30.0f)
               // {

                    //inventory.Add( team1Tracker);
                    //error -use of unassiged local varible "inventory",- trying to add to inventory , plus testing list/arrays  with a distance rule
               // }
          //  }
            
            inventory = new List<Team1Tracker>(gos);
            inventory.Sort(delegate (Team1Tracker a, Team1Tracker b)
            {
                return Vector3.Distance(a.transform.position, TargetlastPos).CompareTo(Vector3.Distance(b.transform.position, TargetlastPos));
            }

           );
            Debug.Log(inventory);
            mole.Team1Contract = TargetlastPos;
            Team1Tracker game = inventory[1];
            mole.Team1closet1 = game.gameObject;
            Team1Tracker game2 = inventory[2];
            mole.Team1closet2 = game2.gameObject;
            Team1Tracker game3 = inventory[3];
            mole.Team1closet3 = game3.gameObject;
            mole.ToMoleTeam1();

            gos = new Team1Tracker[0];

        }
    }

    void EnemyPostion()
    {
        TargetlastPos = Target.transform.position;
    }

    public void SearchLastPostion()
    {
        SearchPoint1 = Random.insideUnitSphere * SearchArea + TargetlastPos;
        SearchPoint2 = Random.insideUnitSphere * SearchArea + TargetlastPos;
        SearchPoint3 = Random.insideUnitSphere * SearchArea + TargetlastPos;
        animator.SetBool("SearchPoint", true);
    }

    public void SearchLastPostionBattleMole()
    {
        SearchPoint1 = Random.insideUnitSphere * SearchArea + BmoleTargetLastPostion;
        SearchPoint2 = Random.insideUnitSphere * SearchArea + BmoleTargetLastPostion;
        SearchPoint3 = Random.insideUnitSphere * SearchArea + BmoleTargetLastPostion;
        animator.SetBool("SearchPoint", true);
    }

   public  void MakeSearchPoints()
    {
        if (SearchPointRef != null) { Destroy(SearchPointRef); }
        SearchPoint1.y = gameObject.transform.position.y;
        SearchPointRef = Instantiate(Empty, SearchPoint1, Quaternion.identity);
        if (SearchPointRef2 != null) { Destroy(SearchPointRef2); }
        SearchPoint2.y = gameObject.transform.position.y;
        SearchPointRef2 = Instantiate(Empty, SearchPoint2, Quaternion.identity);
        if (SearchPointRef3 != null) { Destroy(SearchPointRef3); }
        SearchPoint3.y = gameObject.transform.position.y;
        SearchPointRef3 = Instantiate(Empty, SearchPoint3, Quaternion.identity);
        animator.SetBool("HasSearchPoints", true);
    }
    
   public void SearchPoint1Action()
    {
        navMeshAgent.SetDestination(SearchPointRef.transform.position);
    }

    public void DistanceToSearchPointUpdate()
    {
        animator.SetFloat("DistanceToSearch", DistanceToSearchPoint);
        if (No1 == true)
        {
            DistanceToSearchPoint = Vector3.Distance(gameObject.transform.position, SearchPointRef.transform.position);
        }
        if (No2 == true)
        {
            DistanceToSearchPoint = Vector3.Distance(gameObject.transform.position, SearchPointRef2.transform.position);
        }
        if (No3 == true)
        {
            DistanceToSearchPoint = Vector3.Distance(gameObject.transform.position, SearchPointRef3.transform.position);
        }
    }
   public void SearchPoint2Action()
    {
        navMeshAgent.SetDestination(SearchPointRef2.transform.position);
    }
   public void SearchPoint3Action()
    {
        navMeshAgent.SetDestination(SearchPointRef3.transform.position);
    }


    public void clear()
    {
        spawn = null;
        spawn = GameObject.FindWithTag(Spawntag);
        waypoints = null;
        waypoints = spawnobject.GetComponent<respawn>().waypoints;
        waypoints2 = null;
        waypoints2 = spawnobject.GetComponent<respawn>().waypoints2;
        waypoints3 = null;
        waypoints3 = spawnobject.GetComponent<respawn>().waypoints3;
    }


    public void BattleMoleTrue()
    {
        animator.SetBool("IsBmoleTrue", true);
        Invoke("BacktofalseBmole", 30);
    }

    public void BacktofalseBmole()
    {
        animator.SetBool("IsBmoleTrue", false);
        animator.SetBool("HasSearchPoints", false);
        animator.SetBool("SearchPoint", false);
        animator.SetBool("No3", false);
        animator.SetBool("No2", false);
        animator.SetBool("No1", false);
    }

    private void FlagCheck()
    {
        DistanceFromFlag = Vector3.Distance(gameObject.transform.position, Flag.transform.position);
        animator.SetFloat("FlagDistance", DistanceFromFlag);
        FlagFromZone = Vector3.Distance(FlagZone.transform.position, Flag.transform.position);
        animator.SetFloat("FlagFromZone", FlagFromZone);
        FlagFromEnemyZone = Vector3.Distance(EnemyFlagZone.transform.position, Flag.transform.position);
        animator.SetFloat("FlagDistanceToEnemyZone", FlagFromEnemyZone);
        FlagMaster flagMaster = FindObjectOfType<FlagMaster>();
        if(flagMaster.Team1HasFlag == true)
        {
            if (Enemytag == "Team2")
            {
                animator.SetBool("TeamHasFlag", true);
                animator.SetBool("EnemyHasFlag", false);
                animator.SetBool("FlagFree", false);
            }
            if (Enemytag == "Team1")
            {
                animator.SetBool("EnemyHasFlag", true);
                animator.SetBool("TeamHasFlag", false);
                animator.SetBool("FlagFree", false);
            }
        }
        if (flagMaster.Team2HasFlag == true)
        {
            if (Enemytag == "Team1")
            {
                animator.SetBool("TeamHasFlag", true);
                animator.SetBool("EnemyHasFlag", false);
                animator.SetBool("FlagFree", false);
            }
            if (Enemytag == "Team2")
            {
                animator.SetBool("EnemyHasFlag", true);
                animator.SetBool("TeamHasFlag", false);
                animator.SetBool("FlagFree", false);
            }
        }
        if (flagMaster.flagFree == true)
        {
            animator.SetBool("TeamHasFlag", false);
            animator.SetBool("EnemyHasFlag", false);
            animator.SetBool("FlagFree", true);
        }
        
            FlagCarrier = flagMaster.FlagCarier;
    }

    private void Flagswitch()
    {
        int num = Random.Range(0, 100);
        if(num <= 25)
        {
            GetFlag = true;
            animator.SetBool("GetFlag", true);
        }
    }


    public void MoveToFlag()
    {
        navMeshAgent.SetDestination(Flag.transform.position);
    }

    public void ProtectFlagCarrier()
    {
        ProtectFlagLoc = Random.insideUnitSphere * 10 + FlagCarrier.transform.position;
        ProtectFlagLoc.y = gameObject.transform.position.y;
        if (SearchPointRef != null) { Destroy(SearchPointRef); }
        SearchPointRef = Instantiate(Empty, ProtectFlagLoc, Quaternion.identity);
        navMeshAgent.SetDestination(SearchPointRef.transform.position);
        InvokeRepeating("ProtectLocDistance", 0.0f, 0.2f);
    }

    private void ProtectLocDistance()
    {
        DistanceToSearchPoint = Vector3.Distance(gameObject.transform.position, SearchPointRef.transform.position);
        animator.SetFloat("ProtectLocDistance", DistanceToSearchPoint);
    }

    IEnumerator ProtectWait()
    {
        animator.SetBool("LocWait", true);
        CancelInvoke("ProtectLocDistance");
        RandomNumber = Random.Range(5, 20);
        yield return new WaitForSeconds(RandomNumber);
        animator.SetBool("LocWait", false);
        CancelInvoke("ProtectWait");
    }

    public void MoveToEnemyFlagZone()
    {
        navMeshAgent.SetDestination(EnemyFlagZone.transform.position);
    }

    public void AttackFlagCarrier()
    {
        navMeshAgent.SetDestination(FlagCarrier.transform.position);
    }

    public void FlagSetUp()
    {
        IsgamemadeFlag = true;
        InvokeRepeating("FlagCheck", 0.0f, 0.3f);
        InvokeRepeating("Flagswitch", 4.0f, 4.0f);
        animator.SetBool("FlagGameMode", true);
        animator.SetBool("FlagSysterm", true);
    }
    public void DropFlagDead()
    {
        Flag.transform.position = FlagDeathDrop.transform.position;
        Flag.transform.parent = null;
    }

    public void FlagScore()
    {
        FlagCaptured +=1;
        if (Enemytag == "Team1")
        {
            FindObjectOfType<Score_Master>().flagslosted += 1;
        }
        if (Enemytag == "Team2")
        {
            FindObjectOfType<Score_Master>().flagsg += 1;
        }
        FindObjectOfType<Score_Master>().newscore();
    }

    public void ZoneCaptureEnter()
    {
        int num = Random.Range(1, 2);
        if(num == 1)
        {
            animator.SetBool("ZoneA", true);
        }
        if (num == 2)
        {
            animator.SetBool("ZoneB", true);
        }
    }

    public void ZoneWait()
    {

    }

    public void ZoneUpdater()
    {
        ZoneADis = Vector3.Distance(gameObject.transform.position, ZoneA.transform.position);
        ZoneBDis = Vector3.Distance(gameObject.transform.position, ZoneB.transform.position);
    }
   
    public void ZoneSwitch()
    {
        int num = Random.Range(0, 100);
        if (num <= 20)
        {
            if (animator.GetBool("GoToZone") == false)
            {
                animator.SetBool("GoToZone", true);
                ZoneCaptureEnter();
            }
            else
            {
                animator.SetBool("GoToZone", false);
            }
        }
    }
    public void ZoneSetUp()
    {
        InvokeRepeating("ZoneSwitch", 10.0f, 10.0f);
        InvokeRepeating("ZoneUpdater", 0.0f, 0.3f);
        animator.SetFloat("ZoneADis", ZoneADis);
        animator.SetFloat("ZoneBDis", ZoneBDis);
        animator.SetBool("IsZonemodeTrue", true);

    }

    public void ZoneARandom()
    {
        Vector3 Vector3ZoneA;
        Vector3ZoneA = Random.insideUnitSphere * 7 + ZoneA.transform.position;
        Vector3ZoneA.y = ZoneA.transform.position.y;
    }
    public void ZoneBRandom()
    {
        Vector3 Vector3ZoneB;
        Vector3ZoneB = Random.insideUnitSphere * 7 + ZoneB.transform.position;
        Vector3ZoneB.y = ZoneB.transform.position.y;
    }
    public void ZoneWaitFalse()
    {
        animator.SetBool("Zonewait", true);
    }

}