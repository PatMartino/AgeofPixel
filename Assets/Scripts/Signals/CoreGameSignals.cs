using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onSpecialAbilityCooldown = delegate {  };
        public UnityAction onPlayerMeteorMovement = delegate {  };
        public UnityAction onPlayerMeteorSetRandomPlace = delegate {  };
        public  UnityAction onCPUMeteorMovement = delegate {  };
    }
}
