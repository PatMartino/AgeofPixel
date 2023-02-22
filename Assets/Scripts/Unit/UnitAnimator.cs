using Signals;
using UnityEngine;

namespace Unit
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        private void OnEnable()
        {
            animator = GetComponent<Animator>();
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
        private void OnIdleAnimation()
        {
            animator.Play("Idle");
        }
        private void OnWalkingAnimation()
        {
            animator.Play("Walk");
        }
        private void OnAttackingAnimation()
        {
            animator.Play("Attack");
        }
        private void OnDyingAnimation()
        {
            animator.Play("Die");
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}
