using UnityEngine;

namespace Meteors
{
    public class MeteorPlayer : MonoBehaviour
    {
        private int _xPosition;
        private int _yPosition;
        void Start()
        {
            _xPosition = Random.Range(1, 4);
            _yPosition = Random.Range(1, 4);
            transform.position= new Vector3(_xPosition, _yPosition, 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
