using System;
using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onSpecialAbilityCooldown = delegate {  };
        public UnityAction onPlayerMeteorMovement = delegate {  };
        public UnityAction onPlayerMeteorSetRandomPlace = delegate {  };
        public UnityAction onCPUMeteorMovement = delegate {  };
        public UnityAction<int> haveEnoughMoney = delegate {  };
        public UnityAction onInstantiateSwordsman = delegate {  };
        public UnityAction onInstantiateArcher = delegate {  };
        public UnityAction<int> onKillEnemyUnit = delegate {  };
        public UnityAction<int> onEarningMoney = delegate {  };
    }
}
