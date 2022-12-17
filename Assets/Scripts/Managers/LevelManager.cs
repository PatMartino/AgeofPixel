using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PlayerFunctions playerFunctions;
    public void SwordsmanButton()
    {      
        Object.Instantiate(Resources.Load<GameObject>("Swordsman"), new Vector3(-9, 0, 0), Quaternion.identity);     
    }
    public void ArcherButton()
    {
        Object.Instantiate(Resources.Load<GameObject>("Archer"), new Vector3(-9, 0, 0), Quaternion.identity);
    }
}
