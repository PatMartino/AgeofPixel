using System.Collections;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyUnitSpawnPoint;
        private int _unitNumber;
        private float _unitTime;
        private float _meteorTime;
        private IEnumerator _enumerator;
        private IEnumerator _enumerator1;

        private void OnEnable()
        {
            SubscribeEvents();
            AISignals.Instance.onCPUMeteorUsing?.Invoke();
        }

        private void Start()
        {
            _enumerator1 = MeteorTimer();
            _enumerator = Spawn();
            AISignals.Instance.onEnemyUnitSpawning?.Invoke();
        }

        private void SubscribeEvents()
        {
            AISignals.Instance.onEnemyUnitSpawning += OnEnemyUnitSpawning;
            AISignals.Instance.onCPUMeteorUsing += OnCPUMeteorUsing;
        }

        private void OnCPUMeteorUsing()
        {
            _enumerator1 = MeteorTimer();
            StartCoroutine(_enumerator1);
        }

        IEnumerator MeteorTimer()
        {
            _meteorTime = Random.Range(10, 30);
            yield return new WaitForSeconds(_meteorTime);
            CoreGameSignals.Instance.onCPUMeteorMovement?.Invoke();
            AISignals.Instance.onCPUMeteorUsing?.Invoke();
        }

        private void OnEnemyUnitSpawning()
        {
            _enumerator = Spawn();
            StartCoroutine(_enumerator);
        }

        private IEnumerator Spawn()
        {
            _unitNumber = Random.Range(0, 2);
            _unitTime = Random.Range(4, 12);
            yield return new WaitForSeconds(_unitTime);
            Debug.LogWarning("Bum");
            EnemyUnitSpawn();
        }

        private void EnemyUnitSpawn()
        {
            switch (_unitNumber)
            {
                case 0:
                    Instantiate(Resources.Load<GameObject>("Swordsman(Enemy)"), enemyUnitSpawnPoint.transform.position, Quaternion.identity);
                    AISignals.Instance.onEnemyUnitSpawning.Invoke();
                    break;
                case 1:
                    Instantiate(Resources.Load<GameObject>("Enemy_Archer"), enemyUnitSpawnPoint.transform.position, Quaternion.identity);
                    AISignals.Instance.onEnemyUnitSpawning.Invoke();
                    break;
            }
        }
    }
}
