using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimationSpriteReader))]
public class EditorAnimationSpriteReader : Editor
{
    public void Awake() {
        Debug.Log("Awake");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUI.changed)
        {
            AnimationSpriteReader reader = (AnimationSpriteReader)target;
            if (reader._currentAnimationSprite != null&&reader._currentAnimationSprite.sprites!=null) {
                if (reader._spriteRenderer == null) {
                    reader._spriteRenderer = reader.transform.GetComponent<SpriteRenderer>();
                }
                reader._spriteRenderer.sprite = reader._currentAnimationSprite.sprites[0];
            }
        }
    }
}