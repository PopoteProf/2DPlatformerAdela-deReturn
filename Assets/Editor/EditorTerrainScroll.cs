using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainScroll))]
public class EditorTerrainScroll : Editor {
   public override void OnInspectorGUI() {
      base.OnInspectorGUI();
      if (GUILayout.Button("Rest")) { 
         (target as TerrainScroll).ResetGroupPositions();
      }
   }
}
