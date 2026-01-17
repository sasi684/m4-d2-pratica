using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private SphereScript _spherePrefab;
    [SerializeField] private int _maxNumberOfSpheres = 50;

    private List<SphereScript> _spheresList = new List<SphereScript>();
    public void SpawnSphere()
    {
        if (_spheresList.Count < _maxNumberOfSpheres)
        {
            SphereScript sphere = Instantiate(_spherePrefab);
            sphere.transform.position = Vector3.zero;
            float speed = Random.Range(1f, 5f);
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            sphere.Setup(speed, direction);
            _spheresList.Add(sphere);
        }
    }
}
