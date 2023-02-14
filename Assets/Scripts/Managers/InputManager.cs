using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera myCamera;
        void Update()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                myCamera.transform.Translate(-0.02f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                myCamera.transform.Translate(0.02f, 0, 0);
            }
        }
    }
}
