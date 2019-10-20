using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (AIPowerUpPickup))]
public class AIPowerUpEditor : Editor
{
    // Handles visualisation of the AI power up arc
    void OnSceneGUI()
    {
        AIPowerUpPickup pp = (AIPowerUpPickup)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(pp.transform.position, Vector3.up, Vector3.forward, 360, pp.radius);
        Vector3 viewAngleA = pp.DirFromAngle(-pp.angle / 2, false);
        Vector3 viewAngleB = pp.DirFromAngle(pp.angle / 2, false);

        Handles.DrawLine(pp.transform.position, pp.transform.position + viewAngleA * pp.radius);
        Handles.DrawLine(pp.transform.position, pp.transform.position + viewAngleB * pp.radius);

        Handles.color = Color.red;
        foreach (Transform validPower in pp.PowerUps)
        {
            Handles.DrawLine(pp.transform.position, validPower.position);
        }
    }
}