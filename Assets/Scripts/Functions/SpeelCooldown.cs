using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class SpeelCooldown : MonoBehaviour
{
    [FormerlySerializedAs("_imageCooldown")] [SerializeField]
    private Image imageCooldown;
    [FormerlySerializedAs("_textCooldown")] [SerializeField]
    private TMP_Text textCooldown;

    private bool _isCooldown = true;
    private float _cooldownTime = 10.0f;
    private float _cooldownTimer = 0.0f;
    
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
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
            _isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            _cooldownTimer = _cooldownTime;
            
        }
    }
}
