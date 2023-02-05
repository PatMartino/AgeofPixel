using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject player1UnitSpawnPoint;
        PlayerFunctions _playerFunctions;
        public void SwordsmanButton()
        {      
            Object.Instantiate(Resources.Load<GameObject>("Swordsman"), player1UnitSpawnPoint.transform.position, Quaternion.identity);     
        }
        public void ArcherButton()
        {
            Object.Instantiate(Resources.Load<GameObject>("Archer"), player1UnitSpawnPoint.transform.position, Quaternion.identity);
        }
    } 
}

