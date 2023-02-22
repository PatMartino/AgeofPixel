using UnityEngine;
using Signals;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject player1UnitSpawnPoint;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onClickedSwordsmanButton += OnClickedSwordsmanButton;
            UISignals.Instance.onClickedArcherButton += OnClickedArcherButton;
            CoreGameSignals.Instance.onInstantiateSwordsman += OnInstantiateSwordsman;
            CoreGameSignals.Instance.onInstantiateArcher += OnInstantiateArcher;
            CoreGameSignals.Instance.onKillEnemyUnit += OnKillEnemyUnit;
        }

        private void OnClickedSwordsmanButton()
        { 
            CoreGameSignals.Instance.haveEnoughMoney?.Invoke(1);
        }

        private void OnClickedArcherButton()
        { 
            CoreGameSignals.Instance.haveEnoughMoney?.Invoke(2);
        }
        
        private void OnInstantiateSwordsman()
        {
            Instantiate(Resources.Load<GameObject>("Swordsman"), player1UnitSpawnPoint.transform.position, Quaternion.identity);
        }
        
        private void OnInstantiateArcher()
        {
            Instantiate(Resources.Load<GameObject>("Archer"), player1UnitSpawnPoint.transform.position, Quaternion.identity);
        }

        private void OnKillEnemyUnit(int revenue)
        {
            CoreGameSignals.Instance.onEarningMoney?.Invoke(revenue);
        }


    } 
}

