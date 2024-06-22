using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private Renderer _renderer;

    public int SeparationChance { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initiate(Color color, int chance)
    {
        _renderer.material.SetColor(ColorID, color); 
        SeparationChance = chance;
    }
}
