using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class Castles : MonoBehaviour
{
    public int castle1Hp=100;
    public int castle2Hp=100;

    [SerializeField]
    private GameManager gameManager;
    
    public void Stop()
    {
        Time.timeScale = 0.0f;
    }
}
