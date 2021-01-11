using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Damage Resistance", menuName = "Damage Resisance")]

public class DamageResistance : ScriptableObject
{

    [System.Serializable]
    public struct Resistance
    {
        public DamgeTypes damgeTypes;
        public int percentagToTake;
        public int MinPerToTake;
        public int MaxPerToTake;
      
    }

    public void OnEnable()
    {
      // Tt = Random.Range(MinPerToTake, MaxPerToTake);
      
    }
   

    public List<Resistance> resistances = new List<Resistance>();
   


    public int CalculateDamageWihresis(int damage, DamgeTypes damgeTypes, int MinPerToTake, int MaxPerToTake)
    {
        
        

        for(int i=0;  i < resistances.Count; i++)
        {
            if(resistances[i].damgeTypes == damgeTypes)
            {
                

                return ((damage * resistances[i].percentagToTake) / 100);
            }
            if (resistances [i].MinPerToTake == MinPerToTake)
            {
                return ((resistances[i].MinPerToTake));
            }
            if (resistances[i].MaxPerToTake == MaxPerToTake)
            {
                return ((resistances[i].MaxPerToTake));
            }

        }
        return 0;
    }
}
