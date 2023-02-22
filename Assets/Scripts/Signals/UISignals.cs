using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction onClickedSwordsmanButton = delegate {  };
        public UnityAction onClickedArcherButton = delegate {  };
    }
}
