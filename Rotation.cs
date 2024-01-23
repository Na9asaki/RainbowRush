using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed = 0.125f;

    private void Update()
    {
        Vector3 t = Vector3.RotateTowards(transform.up, transform.right, _speed, 0.0f);
        Vector3 direct = new Vector3(t.x, t.y, 0);
        transform.up = direct;
    }
}
