using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeelCooldown : MonoBehaviour
{
    [SerializeField]
    private Image _imageCooldown;
    [SerializeField]
    private TMP_Text _textCooldown;

    private bool _isCooldown = true;
    private float _cooldownTime = 10.0f;
    private float _cooldownTimer = 0.0f;
    
    void Start()
    {
        _textCooldown.gameObject.SetActive(false);
        _imageCooldown.fillAmount = 0.0f;
        _cooldownTimer = _cooldownTime;
    }

    
    void Update()
    {     
        if (_isCooldown)
        {
            ApplyCooldown();
        }
    }
    void ApplyCooldown()
    {
        
        _cooldownTimer -= Time.deltaTime;
        
        if (_cooldownTimer < 0.0f)
        {
            _isCooldown = false;
            _textCooldown.gameObject.SetActive(false);
            _imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            _textCooldown.gameObject.SetActive(true);
            _textCooldown.text = Mathf.RoundToInt(_cooldownTimer).ToString();
            _imageCooldown.fillAmount = _cooldownTimer / _cooldownTime;
        }
    }
    public void UseSpell()
    {
        if (_isCooldown)
        {
            
        }
        else
        {
            _isCooldown = true;
            _textCooldown.gameObject.SetActive(true);
            _cooldownTimer = _cooldownTime;
            
        }
    }
}
