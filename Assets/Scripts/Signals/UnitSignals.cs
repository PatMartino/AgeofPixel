using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class UnitSignals : MonoSingleton<UnitSignals>
    {
        public UnityAction onIdleAnimation = delegate {  };
        public UnityAction onWalkingAnimation = delegate {  };
        public UnityAction onAttackingAnimation = delegate {  };
        public UnityAction onDyingAnimation = delegate {  };
    }
}
