using System;
using TMPro;
using UnityEngine;

public class UITopLeftPanels : MonoBehaviour
{
        [SerializeField] private TMP_Text _txtGold;
        [SerializeField] private TMP_Text _txtScore;

        private void Start() {
                StaticData.OnPlayerGoldChange+= StaticDataOnOnPlayerGoldChange;
                StaticData.OnPlayerScoreChange+= StaticDataOnOnPlayerScoreChange;
                _txtGold.text = StaticData.PlayerGold.ToString();
                _txtScore.text = StaticData.PlayerScore.ToString();
        }

        private void OnDestroy() {
                StaticData.OnPlayerGoldChange-= StaticDataOnOnPlayerGoldChange;
                StaticData.OnPlayerScoreChange-= StaticDataOnOnPlayerScoreChange;
        }


        private void StaticDataOnOnPlayerScoreChange(object sender, int e) {
                _txtScore.text = e.ToString();
        }

        private void StaticDataOnOnPlayerGoldChange(object sender, int e) {
                _txtGold.text = e.ToString();
        }
}