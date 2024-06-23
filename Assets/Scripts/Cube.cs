using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private Renderer _renderer;

    public int SeparationChance { get; private set; } = 100;

    public float ExplosionForce { get; private set; } = 200f;

    public float ExplosionRadius { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        ExplosionRadius = transform.localScale.x;
    }

    public void Initiate(Color color, int chance, float explosionForce, float explosionRadius, Vector3 scale)
    {
        _renderer.material.SetColor(ColorID, color);
        SeparationChance = chance;
        ExplosionForce = explosionForce;
        ExplosionRadius = explosionRadius;
        transform.localScale = scale;
    }
}
