using System;
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
        public UnityAction<Unit.Unit> onMovement = delegate { };
        public Action<Unit.Unit> onAttack = delegate { };
        public UnityAction<Transform,int> onGivingDamage =delegate {  };
        public Action<bool,bool,Transform,Animator,int> onCastleAttack=delegate {  };
        public UnityAction<Unit.Unit, int> setCanMove =delegate {  };
        public UnityAction<Unit.Unit, int> setIsAttack =delegate {  };
        public UnityAction<Unit.Unit, int> setCanMove2 =delegate {  };
        public UnityAction<Unit.Unit> stopMovement = delegate {  };
    }
}
