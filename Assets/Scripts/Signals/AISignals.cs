using UnityEngine;
using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class AISignals : MonoSingleton<AISignals>
    {
        public UnityAction onUnitTimer = delegate {  };
        public UnityAction onTimer = delegate {  };
        public UnityAction onEnemyUnitSpawning = delegate {  };
        public UnityAction onCPUMeteorUsing = delegate {  };
    }
}
