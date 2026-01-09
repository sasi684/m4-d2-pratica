using UnityEngine;

public class Instatiatior3D : MonoBehaviour
{
    [SerializeField] private MeshRenderer _cubePrefab;
    [SerializeField] private Transform _grid3D;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private int _depthColumns;
    [SerializeField] private float _horizontalOffset;
    [SerializeField] private float _verticalOffset;
    [SerializeField] private float _depthOffset;

    void Awake()
    {
        if (!_cubePrefab) Debug.LogError($"Nessun Prefab di un Cubo inserito nell'Inspector di {name}");

        _grid3D = transform;
        if (!_grid3D) Debug.LogError($"Nessun Transform di riferimento per la posizione della griglia 3D inserito nell'Inspector di {name}");

        if (_rows > 13 || _columns > 25 || _depthColumns > 15) Debug.LogError("La dimensione massima della griglia 3D e' di 25x13x15");
    }

    void Start()
    {
        Vector3 gridPosition = _grid3D.position;

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                for (int k = 0; k < _depthColumns; k++)
                {
                    MeshRenderer quad = Instantiate(_cubePrefab, _grid3D);
                    quad.transform.position = gridPosition;
                    gridPosition.z += _depthOffset;
                }
                gridPosition.z -= _depthOffset * _depthColumns;
                gridPosition.x += _horizontalOffset;
            }
            gridPosition.x -= _horizontalOffset * _columns;
            gridPosition.y += _verticalOffset;
        }
    }
}
