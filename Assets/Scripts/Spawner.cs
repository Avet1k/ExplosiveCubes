using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int _scaleDivider = 2;
    
    private void OnMouseDown()
    {
        var quantity = Random.Range(_minQuantity, _maxQuantity + 1);

        for (int i = 1; i < quantity; i++)
        {
            var newObject = Instantiate(gameObject, transform.position, Quaternion.identity);
            newObject.transform.localScale /= _scaleDivider;
            
            var newObjectMaterial = newObject.GetComponent<Material>();
            // newObjectMaterial.SetColor();
        }
    }
}
