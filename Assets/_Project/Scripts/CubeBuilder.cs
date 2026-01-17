using UnityEngine;

public class CubeBuilder : MonoBehaviour
{
    [SerializeField] private MeshRenderer _cubePrefab;
    [SerializeField] private Transform _cubePerimeter;
    [SerializeField] private int _cubeSize;
    [SerializeField] private float _horizontalOffset;
    [SerializeField] private float _verticalOffset;
    [SerializeField] private float _depthOffset;

    void Awake()
    {
        if (!_cubePrefab) Debug.LogError($"Nessun Prefab di un Cubo inserito nell'Inspector di {name}");

        _cubePerimeter = transform;
        if (!_cubePerimeter) Debug.LogError($"Nessun Transform di riferimento per la posizione del cubo inserito nell'Inspector di {name}");

        if (_cubeSize > 20) Debug.LogError("La dimensione massima del cubo e' di 20x20x20");
    }

    void Start()
    {
        float startX = _cubePerimeter.position.x - ((float)_cubeSize / 2) + 0.5f;
        float startY = _cubePerimeter.position.y - ((float)_cubeSize / 2) + 0.5f;
        float startZ = _cubePerimeter.position.z - ((float)_cubeSize / 2) + 0.5f;
        Vector3 gridPosition = new Vector3(startX, startY, startZ);

        for (int i = 0; i < _cubeSize; i++)
        {
            for (int j = 0; j < _cubeSize; j++)
            {
                for (int k = 0; k < _cubeSize; k++)
                {
                    if (i == 0 || i == _cubeSize - 1 || j == 0 || j == _cubeSize - 1 || k == 0 || k == _cubeSize - 1)
                    {
                        MeshRenderer cube = Instantiate(_cubePrefab, _cubePerimeter);
                        cube.transform.position = gridPosition;
                    }
                    gridPosition.z += _depthOffset;
                }
                gridPosition.z -= _depthOffset * _cubeSize;
                gridPosition.x += _horizontalOffset;
            }
            gridPosition.x -= _horizontalOffset * _cubeSize;
            gridPosition.y += _verticalOffset;
        }
        FindAnyObjectByType<SphereManager>().SpawnSphere();
    }
}
