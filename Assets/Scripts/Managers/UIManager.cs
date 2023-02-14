using System;
using TMPro;
using UnityEngine;
using Signals;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TextMeshProUGUI congratulationsText;
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onButtonClickedSpecialAbility += OnClickedSpecialAbility;
        }

        private static void OnClickedSpecialAbility()
        {
        }

        public void EndGamePanel(int caseNum)
        {
            endGamePanel.SetActive(true);
            switch (caseNum)
            {
                case 1:
                    congratulationsText.text = "Player1 Wins!!!";
                    break;
                case 2:
                    congratulationsText.text = "Player2 Wins!!!";
                    break;
            }
        }
    }
}
