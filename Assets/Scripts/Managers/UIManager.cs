using TMPro;
using UnityEngine;
using Signals;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TextMeshProUGUI congratulationsText;

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

        public void SwordsmanButton()
        {
            UISignals.Instance.onClickedSwordsmanButton?.Invoke();
        }

        public void ArcherButton()
        {
            UISignals.Instance.onClickedArcherButton?.Invoke();
        }
    }
}
