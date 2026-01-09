using UnityEngine;

public class Instantiator2D : MonoBehaviour
{
    [SerializeField] private MeshRenderer _quadPrefab;
    [SerializeField] private Transform _grid;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private float _horizontalOffset;
    [SerializeField] private float _verticalOffset;

    void Awake()
    {
        if (!_quadPrefab) Debug.LogError($"Nessun Prefab di un Quad inserito nell'Inspector di {name}");
        if (!_grid) Debug.LogError($"Nessun Transform di riferimento per la posizione della griglia inserito nell'Inspector di {name}");
        if (_rows > 13 || _columns > 25) Debug.LogError("La dimensione massima della griglia e' di 25x13");
    }

    void Start()
    {
        Vector3 gridPosition = _grid.position;

        for(int i = 0; i < _rows; i++)
        {
            for(int j = 0; j < _columns; j++)
            {
                MeshRenderer quad = Instantiate(_quadPrefab, _grid);
                quad.transform.position = gridPosition;
                gridPosition.x += _horizontalOffset;
            }
            gridPosition.x = gridPosition.x - (_horizontalOffset * _columns);
            gridPosition.z += _verticalOffset;
        }
    }
}
