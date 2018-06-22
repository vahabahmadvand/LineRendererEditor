using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineRenderer))]
public class LineRendererEditor : Editor
{
    LineRenderer lr;

    public void OnEnable()
    {
        lr = (LineRenderer)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        GUI.color = Color.green;
        if (GUILayout.Button("+", GUILayout.MinHeight(50)))
        {
            var temp = lr.GetPosition(lr.positionCount-1);
            lr.positionCount += 1;
            lr.SetPosition(lr.positionCount-1 , temp + new Vector3(1,0,0));
            EditorUtility.SetDirty(target);
        }
        GUILayout.Space(10);
        GUI.color = Color.red;
        if (GUILayout.Button("-", GUILayout.MaxHeight(50)))
        {
            if(lr.positionCount > 1)
                lr.positionCount -= 1;
        }
        GUILayout.EndHorizontal();

    }

    void OnSceneGUI()
    {
       for (int i = 0; i < lr.positionCount; i++) {
           var position = lr.GetPosition (i);
           if (lr.useWorldSpace == false) {
               position = lr.transform.TransformPoint (position);
           }
           var newPosition = Handles.PositionHandle (position, Quaternion.identity);
           if (lr.useWorldSpace == false) {
               newPosition = lr.transform.InverseTransformPoint (newPosition);
           }
           lr.SetPosition (i, newPosition);
       }
    }

}
