using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIhealth : MonoBehaviour
{

    public int aihealth;
    int healthcounter;

    bool isdestroyed;
    public GameObject aishellperfab;

    public GameObject turret;
    // Start is called before the first frame update

    [SerializeField] private int healh;
    [SerializeField] private int maxhealth;
    [SerializeField] private DamageResistance damageresis;
    void Awake()
    {
        healthcounter = aihealth;

        
    }

    // Update is called once per frame

    public void DealDamage(int damage, DamgeTypes damgeTypes, int MinPerToTake, int MaxPerToTake)
    {
        healh -= damageresis.CalculateDamageWihresis(damage, damgeTypes,  MinPerToTake,  MaxPerToTake);
        if (healh <= 0)
        {
            Destroy(gameObject);
        }
    }

    void destroyed()
    {
        isdestroyed = true;
       // Instantiate(aishellperfab, transform.position, Quaternion.identity);

        turret.SetActive(false);
    }
}
