using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Cube))]
public class Spawner : MonoBehaviour
{
    private Cube _cube;
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int _scaleDivider = 2;
    private int _chanceDivider = 2;
    private int _maxChance = 100;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnMouseDown()
    {
        if (Random.Range(0, _maxChance + 1) > _cube.SeparationChance)
            return;
        
        var quantity = Random.Range(_minQuantity, _maxQuantity + 1);

        InstantiateCubes(quantity);
    }

    private void InstantiateCubes(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var newCube = Instantiate(gameObject, transform.position, Quaternion.identity);
            var cube = newCube.GetComponent<Cube>();
            var color = RandomColor();
            var chance = cube.SeparationChance / _chanceDivider;
            
            newCube.transform.localScale /= _scaleDivider;
            cube.Initiate(color, chance);
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
