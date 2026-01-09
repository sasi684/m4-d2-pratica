using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private static MeshRenderer _meshRenderer;
    public static Color SelectedColor;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public static void SetSelectedColor(Color color)
    {
        SelectedColor = color;
        _meshRenderer.material.color = color;
    }

    public Color GetColor() => SelectedColor;

}
