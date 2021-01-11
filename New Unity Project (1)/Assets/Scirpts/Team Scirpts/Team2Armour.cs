using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team2Armour : MonoBehaviour
{
    public int resistance;
    [SerializeField] public int damage;
    [SerializeField] public DamgeTypes damgeTypes;
    [SerializeField] public int MinPerToTake;
    [SerializeField] public int MaxPerToTake;
    public DamageResistance test;
    public Tankfsm tankfsm;


}
