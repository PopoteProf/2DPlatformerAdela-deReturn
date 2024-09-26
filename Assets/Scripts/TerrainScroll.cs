using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour
{
    [SerializeField] private TerrainGroup[] _terraingroup;
    [SerializeField] private Transform _ref;

    public void Update() {
        if (_ref == null) return;
        float displayFactor = _ref.position.x;
        foreach (var terrainGroup in _terraingroup) {
            float display = displayFactor * terrainGroup.Coef;

            foreach (var objTransflorm in terrainGroup.Objects) {
                objTransflorm.position = new Vector3(display, 0, 0);
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
