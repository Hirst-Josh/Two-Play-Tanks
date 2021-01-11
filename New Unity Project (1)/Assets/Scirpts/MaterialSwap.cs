using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
   public Material Damage_Material;
   public void Swap()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sharedMaterial = Damage_Material;
    }
}
