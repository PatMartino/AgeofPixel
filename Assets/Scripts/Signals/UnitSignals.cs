using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UnitSignals : MonoSingleton<UnitSignals>
    {
        public UnityAction<Animator> onIdleAnimation = delegate {  };
        public UnityAction<Animator> onWalkingAnimation= delegate {  };
        public UnityAction<Animator> onAttackingAnimation = delegate {  };
        public UnityAction<Animator> onDyingAnimation = delegate {  };
    }
}
