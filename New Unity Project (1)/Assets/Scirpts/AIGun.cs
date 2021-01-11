using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{

    public int timebetweenshots;
    int shottimer;
    public float force = 100f;
    public Transform barrelend;
    public Rigidbody shellprefab;
    bool fired;

    private GameObject target;

    public Tankfsm hull;

    [SerializeField]
    private float turnRateRadians = 2 * Mathf.PI;

    [SerializeField]
    private Transform turret;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = hull.GetComponent<Tankfsm>().Target;
        TargetEnemy();
    }


    void TargetEnemy()
    {

        if (target != null)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            // Rotating in 2D Plane...
            targetDir.y = 0.0f;
            targetDir = targetDir.normalized;

            Vector3 currentDir = turret.forward;

            currentDir = Vector3.RotateTowards(currentDir, targetDir, turnRateRadians * Time.deltaTime, 1.0f);

            Quaternion qDir = new Quaternion();
            qDir.SetLookRotation(currentDir, Vector3.up);
            turret.rotation = qDir;
        }
    }
}
