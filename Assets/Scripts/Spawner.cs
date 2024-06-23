using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Cube)),
 RequireComponent(typeof(Exploder))]
public class Spawner : MonoBehaviour
{
    private Cube _cube;
    private Exploder _exploder;
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int _maxChance = 100;
    private int _scaleDivider = 2;
    private int _chanceDivider = 2;
    private float _forceMultiplier = 2;
    private float _radiusMultiplier = 2;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown()
    {
        if (Random.Range(0, _maxChance + 1) > _cube.SeparationChance)
        {
            _exploder.DetonateOuterCircle();
            return;
        }

        var quantity = Random.Range(_minQuantity, _maxQuantity + 1);

        InstantiateCubes(quantity);
        _exploder.DetonateInsideBox();
    }

    private void InstantiateCubes(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var newCubeInstance = Instantiate(gameObject, transform.position, Quaternion.identity);
            var newCube = newCubeInstance.GetComponent<Cube>();
            
            var color = RandomColor();
            var chance = _cube.SeparationChance / _chanceDivider;
            var force = _cube.ExplosionForce * _forceMultiplier;
            var radius = _cube.ExplosionRadius * _radiusMultiplier;
            var scale = transform.localScale / _scaleDivider;
            
            newCube.Initiate(color, chance, force, radius, scale);
        }
    }

    private Color RandomColor()
    {
        float min = 0.001f;
        float max = 1f;

        var color = new Color(
            r: Random.Range(min, max),
            g: Random.Range(min, max),
            b: Random.Range(min, max));

        return color;
    }
}
