using System;
using UnityEngine;
using Signals;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject uIManager;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.endGame += EndGame;
        }

        public void EndGame(int caseNum)
        {
            switch (caseNum)
            {
                case 1:
                    Time.timeScale = 0.0f;
                    Debug.LogWarning("Player1Wins");
                    uIManager.GetComponent<UIManager>().EndGamePanel(caseNum);
                    break;
                case 2:
                    Time.timeScale = 0.0f;
                    Debug.LogWarning("Player2Wins");
                    uIManager.GetComponent<UIManager>().EndGamePanel(caseNum);
                    break;
            }
        }
    }
}
