using System;
using Signals;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Meteors
{
    public class PlayerMeteors : MonoBehaviour
    {
        private bool _canMove=false;
        private int _xPosition;
        private int _yPosition;
        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlayerMeteorMovement += OnPlayerMeteorMovement;
            //CoreGameSignals.Instance.onPlayerMeteorSetRandomPlace += OnPlayerMeteorSetRandomPlace;
        }
        private void Awake()
        {
            //CoreGameSignals.Instance.onPlayerMeteorSetRandomPlace?.Invoke();
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
            }
            else if(col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
