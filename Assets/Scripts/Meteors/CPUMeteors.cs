using UnityEngine;
using Signals;

namespace Meteors
{
    public class CPUMeteors : MonoBehaviour
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
            CoreGameSignals.Instance.onCPUMeteorMovement += OnCPUMeteorMovement;
        }

        private void Start()
        {
            OnCPUMeteorSetRandomPlace();
        }
    
        private void OnCPUMeteorSetRandomPlace()
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
    
        private void OnCPUMeteorMovement()
        {
            _canMove = true;
        }
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("MeteorReset"))
            {
                OnCPUMeteorSetRandomPlace();
                _canMove = false;
            }
            else if(col.gameObject.CompareTag("Player"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
