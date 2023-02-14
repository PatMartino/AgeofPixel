using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Signals;

namespace Functions
{
    public class SpecialAbility : MonoBehaviour
    {
        [SerializeField]
        private Image imageCooldown;
        [SerializeField]
        private TMP_Text textCooldown;

        private bool _isCooldown = true;
        private readonly float _cooldownTime = 10.0f;
        private float _cooldownTimer = 0.0f;
    
        void Start()
        {
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
            _cooldownTimer = _cooldownTime;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onSpecialAbility += OnSpecialAbility;
            CoreGameSignals.Instance.onSpecialAbilityCooldown += OnSpecialAbilityCooldown;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onSpecialAbility -= OnSpecialAbility;
            CoreGameSignals.Instance.onSpecialAbilityCooldown -= OnSpecialAbilityCooldown;
        }
        

        private void OnSpecialAbility()
        {
            Debug.LogWarning("Tatattaat");
        }

        void Update()
        {     
            if (_isCooldown)
            {
                CoreGameSignals.Instance.onSpecialAbilityCooldown?.Invoke();
            }
        }
        void OnSpecialAbilityCooldown()
        {
            _cooldownTimer -= Time.deltaTime;
        
            if (_cooldownTimer < 0.0f)
            {
                _isCooldown = false;
                textCooldown.gameObject.SetActive(false);
                imageCooldown.fillAmount = 0.0f;
            }
            else
            {
                textCooldown.gameObject.SetActive(true);
                textCooldown.text = Mathf.RoundToInt(_cooldownTimer).ToString();
                imageCooldown.fillAmount = _cooldownTimer / _cooldownTime;
            }
        }
        public void UseSpell()
        {
            if (_isCooldown)
            {
            
            }
            else
            {
                CoreGameSignals.Instance.onPlayerMeteorMovement?.Invoke();
                _isCooldown = true;
                textCooldown.gameObject.SetActive(true);
                _cooldownTimer = _cooldownTime;
            }
        }
        /*private void OnDisable()
        {
            UnSubscribeEvents();
        }*/
    }
}
