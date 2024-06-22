using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _force = 1000f;
    private float _radius = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddExplosionForce(_force, transform.position, _radius);
    }
}
