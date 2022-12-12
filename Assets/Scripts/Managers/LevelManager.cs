using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PlayerFunctions playerFunctions;
    public void Soldier1Button()
    {
        
            Object.Instantiate(Resources.Load<GameObject>("Swordsman"), new Vector3(-9, 0, 0), Quaternion.identity);
            
        
        
    }
}
