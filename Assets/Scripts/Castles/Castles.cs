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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        Time.timeScale = 0.0f;
    }
}
