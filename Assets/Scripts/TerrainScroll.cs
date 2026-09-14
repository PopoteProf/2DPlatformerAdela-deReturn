using System;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainScroll : MonoBehaviour
{
    [SerializeField, Tooltip(" Prevent the scrolling when the player Die. Have to be change before entering play mode"
         )] private bool _StopScrollOnDeath = true; 
    [SerializeField,Tooltip("Target that is use to calculate scrolling amout, generaly the playerCharacter"
         )] private Transform _ref;
    [SerializeField] private TerrainGroup[] _terraingroup;
    
    
    [Space(10)] 
    [Header("Debug")]
    [SerializeField, Tooltip("Allow the scrolling to happen in Editor, perfect for the level design"
         )] private bool _updateInEditor;

    
    
    
    public void Update() {
#if UNITY_EDITOR
        if (!_updateInEditor) return;
#endif
        if (_ref == null) return;
        float displayFactor = _ref.position.x;
        foreach (var terrainGroup in _terraingroup) {
            float display = displayFactor * terrainGroup.Coef;

            foreach (var objTransflorm in terrainGroup.Objects) {
                objTransflorm.position = new Vector3(display, 0, 0);
            }
        }
    }

    public void ResetGroupPositions() {
        foreach (var terrain in _terraingroup) {
            foreach (var transform in terrain.Objects) {
                transform.position = Vector3.zero;
                
            }
        }
    }

    private void Start() {
        if (_StopScrollOnDeath) {
            StaticData.OnPlayerDeath += (sender, args) => enabled = false;
        }
    }

    [Serializable]
    private class TerrainGroup
    {
        public Transform[] Objects;
        public float Coef = 0;
    }
}
