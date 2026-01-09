using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnMouseDown()
    {
        ColorManager.SetSelectedColor(_meshRenderer.material.color);
    }
}