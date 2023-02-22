using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="New Unit", menuName ="Unit")]

    public class UnitData : ScriptableObject
    {
        public string unitName;
        public Sprite artwork;
        public int healthPoint;
        public int attackPower;
        public bool isPlayer;
        public float range;
        public int unitCost;
        public int unitReveune;
    }
}
