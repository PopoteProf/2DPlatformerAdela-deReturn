using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(TestButton))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (TestButton)target;

        EditorStyles.label.fontStyle = FontStyle.Bold;
        script._startingAnimation = EditorGUILayout.Toggle("Starting Animation", script._startingAnimation);
        EditorStyles.label.fontStyle = FontStyle.Normal;
        
        //if (script._startingAnimation)
        //{
           
        script._startingAnimationEndPos = EditorGUILayout.Vector2Field("Start Position", script._startingAnimationEndPos);
        script._startingAnimationEndScale = EditorGUILayout.Vector2Field("Start Scale", script._startingAnimationEndScale);
        script._startingRotation = EditorGUILayout.Vector3Field("Start Rotation", script._startingRotation);
        script._startingPivotPoint = EditorGUILayout.Vector2Field("Start Pivot Point", script._startingPivotPoint);
        script._startingAnimationLenght = EditorGUILayout.FloatField("Start Animation Lenght", script._startingAnimationLenght);
        script._startingAnimationCurve = EditorGUILayout.CurveField("Start AnimationCurve", script._startingAnimationCurve);
       
            
            
            
        //}

        EditorGUILayout.Space();
        EditorStyles.label.fontStyle = FontStyle.Bold;
        EditorGUILayout.Foldout(script._animation, "Animation");
        
        //script._animation = EditorGUILayout.Toggle("Playing Animation", script._animation);
        EditorStyles.label.fontStyle = FontStyle.Normal;

        if (script._animation)
        {
            script._animationEndPos = EditorGUILayout.Vector2Field("End Position", script._animationEndPos);
            script._animationEndScale = EditorGUILayout.Vector2Field("End Scale", script._animationEndScale);
            script._animationRotation = EditorGUILayout.Vector3Field("Start Rotation", script._animationRotation);
            script._pivotPoint = EditorGUILayout.Vector2Field("Pivot Point", script._pivotPoint);
            script._animationLenght = EditorGUILayout.FloatField("Animation Lenght", script._animationLenght);
            script._animationCurve = EditorGUILayout.CurveField("AnimationCurve", script._animationCurve);
            script._mouseDelay = EditorGUILayout.FloatField("Mouse Delay", script._mouseDelay);
        }

        script._shaking = EditorGUILayout.Toggle("Shaking", script._shaking);
        if (script._shaking)
        {
            script._shakeStrength = EditorGUILayout.IntField("Shake Strength", script._shakeStrength);
            script._shakeDistance = EditorGUILayout.IntField("Shake Distance", script._shakeDistance);
        }
            
        
    }
}