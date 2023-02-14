using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onSpecialAbility = delegate {  };
        public UnityAction onSpecialAbilityCooldown = delegate {  };
        public UnityAction onPlayerMeteorMovement = delegate {  };
        public UnityAction onPlayerMeteorSetRandomPlace = delegate {  };
 
    }
}
