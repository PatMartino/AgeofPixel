using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction onButtonClickedSpecialAbility = delegate {  };
    }
}
