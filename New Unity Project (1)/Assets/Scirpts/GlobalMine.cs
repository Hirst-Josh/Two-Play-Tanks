using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMine : MonoBehaviour
{
    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    // Start is called before the first frame update

    public void Boom()
    {
        Destroy(gameObject);
    }
}
