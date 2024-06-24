using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Cube _cube;
    
    public float Force { get; private set; } = 200f;
    
    public float Radius { get; private set; }

    private void Awake()
    {
        Radius = transform.localScale.x;
    }

    public void DetonateInsideBox()
    {
        var halfExtents = transform.localScale / 2;
        Collider[] colliders = Physics.OverlapBox(transform.position, halfExtents, Quaternion.identity,
            _layerMask);

        foreach (var collider in colliders)
        {
            var cube = collider.GetComponent<Cube>();
            cube.GetRigidBody().AddExplosionForce(Force, transform.position, 0);
        }
    }

    public void SetForce(float force)
    {
        Force = force;
    }

    public void SetRadius(float radius)
    {
        Radius = radius;
    }

    public void DetonateOuterCircle()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius, _layerMask);

        foreach (var collider in colliders)
        {
            var cube = collider.GetComponent<Cube>();
            cube.GetRigidBody().AddExplosionForce(Force, transform.position, Radius);
        }
    }
}
