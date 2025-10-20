using System;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainScroll : MonoBehaviour
{
    [SerializeField] private Transform _ref;
    [SerializeField] private TerrainGroup[] _terraingroup;
    
    [Space(10)] 
    [Header("Debug")]
    [SerializeField] private bool _updateInEditor;

    
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

    [Serializable]
    private class TerrainGroup
    {
        public Transform[] Objects;
        public float Coef = 0;
    }
}
