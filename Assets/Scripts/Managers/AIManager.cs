using System.Collections;
using UnityEngine;

namespace Managers
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyUnitSpawnPoint;
        int _unitNumber;
        float _time;
        bool _spawn = false;  
        void Update()
        {
            StartCoroutine(Spawn());
        }
        IEnumerator Spawn()
        {
            while (_spawn == false)
            {
                _spawn = true;
                yield return new WaitForSeconds(1f);
                UnitTimer();
            }
        }
        void UnitTimer()
        {
            
            _unitNumber = Random.Range(0, 2);
            _time = Random.Range(4, 12);
            StartCoroutine(Timer());
            
            
        }
        IEnumerator Timer()
        {
            yield return new WaitForSeconds(_time);
            EnemyUnitSpawn();
            Debug.LogWarning("Bum");
            _spawn = false;
        }
        void EnemyUnitSpawn()
        {
            if (_unitNumber == 0)
            {
                Object.Instantiate(Resources.Load<GameObject>("Swordsman(Enemy)"), enemyUnitSpawnPoint.transform.position, Quaternion.identity);
            }
            else if (_unitNumber == 1)
            {
                Object.Instantiate(Resources.Load<GameObject>("Enemy_Archer"), enemyUnitSpawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
