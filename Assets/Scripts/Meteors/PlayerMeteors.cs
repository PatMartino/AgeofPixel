using UnityEngine;
using Random = UnityEngine.Random;
using Signals;
using Unit;

namespace Meteors
{
    public class PlayerMeteors : MonoBehaviour
    {
        private bool _canMove;
        private int _xPosition;
        private int _yPosition;
        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlayerMeteorMovement += OnPlayerMeteorMovement;
        }

        private void Start()
        {
            OnPlayerMeteorSetRandomPlace();
        }

        private void OnPlayerMeteorSetRandomPlace()
        {
            _xPosition = Random.Range(-2, 24);
            _yPosition = Random.Range(9, 15);

            transform.position=new Vector3(_xPosition, _yPosition, 0);
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                transform.Translate(0,-0.2f,0);
            }
        }

        private void OnPlayerMeteorMovement()
        {
            _canMove = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("MeteorReset"))
            {
                OnPlayerMeteorSetRandomPlace();
                _canMove = false;
            }
            else if(col.gameObject.CompareTag("Enemy"))
            {
                CoreGameSignals.Instance.onKillEnemyUnit?.Invoke(col.GetComponent<Unit.Unit>().unitRevenue);
                Destroy(col.gameObject);
            }
        }
    }
}
