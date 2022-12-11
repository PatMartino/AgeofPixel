using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PlayerFunctions playerFunctions;
    public void Soldier1Button()
    {
        if (playerFunctions.money >= 100)
        {
            Object.Instantiate(Resources.Load<GameObject>("Swordsman"), new Vector3(-9, 0, 0), Quaternion.identity);
            playerFunctions.money -= 100;
        }
        
    }
}
