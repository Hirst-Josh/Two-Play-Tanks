using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TankDrive))]
public class PlayervieweEditor : Editor
{
    private void OnSceneGUI()
    {
        TankDrive fow = (TankDrive)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewradius);
        Vector3 viewnaglea = fow.DirFromangle(-fow.viewangle / 2, false);
        Vector3 viewangleb = fow.DirFromangle(fow.viewangle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewnaglea * fow.viewradius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewangleb * fow.viewradius);

        Handles.color = Color.red;
        foreach (Transform VisableTargets in fow.VisableTargets)
        {
            Handles.DrawLine(fow.transform.position, VisableTargets.position);
        }
    }
}
