using UnityEngine;
using Signals;

namespace Managers
{
    public class MoneyManager : MonoBehaviour
    {
        public int money=250;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.haveEnoughMoney += HaveEnoughMoney;
            CoreGameSignals.Instance.onEarningMoney += OnEarningMoney;
        }
        private void HaveEnoughMoney(int num)
        {
            switch (num)
            {
                case 1:
                    if (money >= 100)
                    {
                        CoreGameSignals.Instance.onInstantiateSwordsman?.Invoke();
                        money -= 100;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (money >= 150)
                    {
                        CoreGameSignals.Instance.onInstantiateArcher?.Invoke();
                        money -= 150;
                        break;
                    }
                    else
                    {

                        break;
                    }
            }
        }
        private void OnEarningMoney(int revenue)
        {
            money += revenue;
        }

    }
}
