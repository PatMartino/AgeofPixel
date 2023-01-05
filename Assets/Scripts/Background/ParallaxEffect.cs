using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] private List<GameObject> layers;
        private Camera _cam;
        [SerializeField] [Range(0,1)] private float parallaxMultiplierOffset = 0;

        private void Awake()
        {
            _cam = FindObjectOfType<Camera>();
        }
        void Update()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].transform.position = new Vector3
                    (_cam.transform.position.x * ((1 - parallaxMultiplierOffset) * i/layers.Count-1) * -1, transform.position.y);
            }
        }
    }
}
