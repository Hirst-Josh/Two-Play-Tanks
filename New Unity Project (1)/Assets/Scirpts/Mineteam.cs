using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineteam : MonoBehaviour
{
    [SerializeField] public float force;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public GameObject Spawner;
    public bool player;
    public GameObject MineExplonsionprefab;
    public AudioClip BoomClip;

    private void Start()
    {
        
    }


    public void Boom()
    {
        Instantiate(MineExplonsionprefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
