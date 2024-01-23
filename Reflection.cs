using UnityEngine;

public class Reflection : MonoBehaviour
{
    [SerializeField] private float _force;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = transform.up;
        Vector3 direct = (collision.GetContact(0).point - collision.gameObject.transform.position).normalized;
        Vector3 forceDirect = Vector3.Reflect(direct, normal) * _force;
        collision.rigidbody.AddForce(forceDirect, ForceMode.VelocityChange);
    }
}
