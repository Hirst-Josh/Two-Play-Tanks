using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class Weather_Holder : MonoBehaviour
{

    public VisualEffect Rain;
    public VisualEffect Snow;

    // Start is called before the first frame update
    void Start()
    {
        Rain.Stop();
        Snow.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopEffects()
    {
        Rain.Stop();
        Snow.Stop();
    }
}
