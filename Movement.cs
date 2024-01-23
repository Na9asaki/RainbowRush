using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _perioud;
    private Vector3 _point1;
    private Vector3 _point2;

    private float t = 0;

    private void Awake()
    {
        _point1 = transform.position;
        _point2 = new Vector3(transform.position.x - transform.localScale.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        t = Mathf.PingPong(Time.time, 1);
        transform.position = Vector3.Lerp(_point1, _point2, t);
    }
}
