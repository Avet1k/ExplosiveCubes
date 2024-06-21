using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
