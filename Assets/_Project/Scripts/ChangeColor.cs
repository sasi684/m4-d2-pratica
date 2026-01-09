using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Camera _camera;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _camera = Camera.main;
    }

    void OnMouseDown()
    {
        _meshRenderer.material.color = ColorManager.SelectedColor;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _meshRenderer.material.SetColor("_BaseColor", default);
        }
    }
}
