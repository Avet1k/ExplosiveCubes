using UnityEngine;

[RequireComponent(typeof(Rigidbody)),
 RequireComponent(typeof(Exploder)),
 RequireComponent(typeof(Destroyer)),
 RequireComponent(typeof(Renderer)),
 RequireComponent(typeof(Spawner))]
public class Cube : MonoBehaviour
{
    private static readonly int s_colorID = Shader.PropertyToID("_Color");

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private Exploder _exploder;
    private Spawner _spawner;
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int _maxChance = 100;
    public int SeparationChance { get; private set; } = 100;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _exploder = GetComponent<Exploder>();
        _spawner = GetComponent<Spawner>();
    }
    
    private void OnMouseDown()
    {
        if (Random.Range(0, _maxChance + 1) > SeparationChance)
        {
            _exploder.DetonateOuterCircle();
            return;
        }

        var quantity = Random.Range(_minQuantity, _maxQuantity + 1);

        _spawner.InstantiateCubes(quantity);
        _exploder.DetonateInsideBox();
    }

    public void Initiate(Color color, int chance, float explosionForce, float explosionRadius, Vector3 scale)
    {
        _renderer.material.SetColor(s_colorID, color);
        SeparationChance = chance;
        _exploder.SetForce(explosionForce);
        _exploder.SetRadius(explosionRadius);
        transform.localScale = scale;
    }

    public Rigidbody GetRigidBody()
    {
        return _rigidbody;
    }
}
