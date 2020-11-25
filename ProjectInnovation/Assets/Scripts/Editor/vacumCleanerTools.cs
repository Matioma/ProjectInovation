using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(VacumCleanerController))]
public class vacumCleanerTools : Editor
{
    public void OnSceneGUI()
    {

        var t = target as VacumCleanerController;

        
        for (int i = 0; i < t.positions.Count; i++) {
            Vector3 position = Handles.PositionHandle(t.positions[i]+ t.transform.position, Quaternion.identity) - t.transform.position;

            t.positions[i] = position;
        }

        Handles.color = Color.green;
        for (int i = 0; i < t.positions.Count-1; i++)
        {
            Handles.DrawLine(t.positions[i] + t.transform.position, t.positions[i + 1] + t.transform.position);
            Debug.Log("Draw");
        }

        //DrawGizmo.

        //Gizmos.DrawCube(t.transform.position, t.start);


        //EditorGUI.BeginChangeCheck();
        //Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);
        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObject(target, "Move point");
        //    t.lookAtPoint = pos;
        //    t.Update();
        //}
    }

}
