using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Cube)),
 RequireComponent(typeof(Exploder))]
public class Spawner : MonoBehaviour
{
    private Cube _cube;
    private Exploder _exploder;
    
    private int _scaleDivider = 2;
    private int _chanceDivider = 2;
    private float _forceMultiplier = 2;
    private float _radiusMultiplier = 2;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _exploder = GetComponent<Exploder>();
    }

    public void InstantiateCubes(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var newCube = Instantiate(_cube, transform.position, Quaternion.identity);
            
            var color = ChooseRandomColor();
            var chance = _cube.SeparationChance / _chanceDivider;
            var force = _exploder.Force * _forceMultiplier;
            var radius = _exploder.Radius * _radiusMultiplier;
            var scale = transform.localScale / _scaleDivider;
            
            newCube.Initiate(color, chance, force, radius, scale);
        }
    }

    private Color ChooseRandomColor()
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
