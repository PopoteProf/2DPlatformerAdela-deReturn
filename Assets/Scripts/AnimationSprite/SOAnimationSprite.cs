using UnityEngine;

[CreateAssetMenu(fileName = "New Animation Sprite", menuName = "So/Animation Sprite")]
public class SOAnimationSprite :ScriptableObject
{
    public float FrameRate = 8;
    public bool AnimationLoop = true;
    public Sprite[] sprites;

    public int FrameCounts {
        get {
            if (sprites == null) return 0;
            return sprites.Length;
        }
    }

    public float TimeBetweenFame {
        get => 1f/FrameRate;
    }
}