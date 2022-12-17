using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Unit", menuName ="Unit")]

public class UnitData : ScriptableObject
{
    public string unitName;
    public Sprite artwork;
    public int healthPoint;
    public int attackPower;
    public bool isPlayer;
    public int range;
    public int unitCost;
    public int unitReveune;
}
