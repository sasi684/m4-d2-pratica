using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private LayerMask _quadLayer;
    private MeshRenderer _meshRenderer;
    private Camera _camera;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _camera = Camera.main;
    }

    //void OnMouseDown()
    //{
    //    _meshRenderer.material.color = ColorManager.SelectedColor;
    //}

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _meshRenderer.material.SetColor("_BaseColor", Color.white);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePos = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos, out RaycastHit hit, _quadLayer))
            {
                var hitMeshRenderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                hitMeshRenderer.material.color = ColorManager.SelectedColor;
            }
        }
    }
}
