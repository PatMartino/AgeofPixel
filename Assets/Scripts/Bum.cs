using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bum : MonoBehaviour
{
    private int _xPosition;
    private int _yPosition;
    void Start()
    {
        _xPosition = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
