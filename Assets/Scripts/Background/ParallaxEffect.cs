using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] private List<GameObject> layers;
        [SerializeField] [Range(0,1)] private float parallaxMultiplierOffset = 0;
        
        private Camera _cam;

        private void Awake()
        {
            _cam = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            AddLayersToList();
        }
        
        void Update()
        {
            MoveLayers();
        }

        private void AddLayersToList()
        {
            foreach (Transform bgLayer in transform)
                layers.Add(bgLayer.gameObject);
        }
        
        private void MoveLayers()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].transform.position = new Vector3
                    (_cam.transform.position.x * ((1 - parallaxMultiplierOffset) * i/layers.Count-1) * -1, transform.position.y);
            }
        }
    }
}
