using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed;
    private Vector3 _direction;
    private SphereManager _sphereManager;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _sphereManager = FindAnyObjectByType<SphereManager>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * _speed;
    }

    public void Setup(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _direction = Vector3.Reflect(_direction, collision.GetContact(0).normal);

        if (collision.collider.TryGetComponent<MeshRenderer>(out var meshRenderer))
            meshRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        if(collision.collider.CompareTag("Cube"))
            _sphereManager.SpawnSphere();
    }
}
