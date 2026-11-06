using NUnit.Framework.Constraints;
using UnityEngine;

[CreateAssetMenu(fileName = "SoGroundType", menuName = "So Ground Type")]
public class SoGroundType : MonoBehaviour
{
    public GroundType type;
    
    public enum GroundType { None, Grass, Dirt, Stone, Wood }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
