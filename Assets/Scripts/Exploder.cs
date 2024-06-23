using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void DetonateInsideBox()
    {
        var halfExtents = transform.localScale / 2;
        Collider[] colliders = Physics.OverlapBox(transform.position, halfExtents, Quaternion.identity,
            _layerMask);

        foreach (var collider in colliders)
        {
            collider.GetComponent<Rigidbody>().AddExplosionForce(_cube.ExplosionForce, transform.position, 0);
        }
    }

    public void DetonateOuterCircle()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _cube.ExplosionRadius, _layerMask);

        foreach (var collider in colliders)
        {
            collider.GetComponent<Rigidbody>().AddExplosionForce(_cube.ExplosionForce, transform.position,
                _cube.ExplosionRadius);
        }
    }
}
