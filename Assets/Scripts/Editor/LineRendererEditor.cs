﻿using System.Collections;
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
        GUI.color = Color.green;
        if (GUILayout.Button("+",GUILayout.MaxHeight(50)))
        {
            lr.positionCount += 1;
            lr.SetPosition(lr.positionCount-1 , Vector3.zero);
        }
        GUILayout.Space(10);
        GUI.color = Color.red;
        if (GUILayout.Button("-", GUILayout.MaxHeight(50)))
        {
            if(lr.positionCount > 1)
                lr.positionCount -= 1;
        }

    }

    void OnSceneGUI()
    {
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, Handles.PositionHandle(lr.GetPosition(i), Quaternion.identity));
        }
    }

}