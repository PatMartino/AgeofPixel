using Signals;
using UnityEngine;

namespace Managers
{
    public class AnimationManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            UnitSignals.Instance.onIdleAnimation += OnIdleAnimation;
            UnitSignals.Instance.onWalkingAnimation += OnWalkingAnimation;
            UnitSignals.Instance.onAttackingAnimation += OnAttackingAnimation;
            UnitSignals.Instance.onDyingAnimation += OnDyingAnimation;
        }
        private void UnSubscribeEvents()
        {
            UnitSignals.Instance.onIdleAnimation -= OnIdleAnimation;
            UnitSignals.Instance.onWalkingAnimation -= OnWalkingAnimation;
            UnitSignals.Instance.onAttackingAnimation -= OnAttackingAnimation;
            UnitSignals.Instance.onDyingAnimation -= OnDyingAnimation;
        }
        private void OnIdleAnimation(Animator animator)
        {
            animator.Play("Idle");
        }
        private static void OnWalkingAnimation(Animator animator)
        {
            animator.Play("Walk");
        }
        private static void OnAttackingAnimation(Animator animator)
        {
            animator.Play("Attack");
        }
        private void OnDyingAnimation(Animator animator)
        {
            animator.Play("Die");
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}
