using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Vector3 _leftDirectionRate;
    [SerializeField] private Vector3 _rightDirectionRate;
    [SerializeField] private float _force;
    [SerializeField] private float _duration;
    [SerializeField] private GameObject[] _objects;

    private Queue<GameObject> _queue;
    private void Start()
    {
        _queue = new Queue<GameObject>();
        foreach (var obj in _objects)
        {
            _queue.Enqueue(obj);
        }
        StartCoroutine(SpawnBalls());
    }

    private void OnDestroy()
    {
        StopCoroutine(SpawnBalls());
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        _queue.Enqueue(other.gameObject);
    }

    private IEnumerator SpawnBalls()
    {
        while (true)
        {
            if (_queue.Count >= 2)
            {
                GameObject t1 = _queue.Dequeue(), t2 = _queue.Dequeue();
                t1.SetActive(true);
                t1.GetComponent<MeshRenderer>().material.SetColor("_ColorTint", Random.ColorHSV());
                t2.SetActive(true);
                t2.GetComponent<MeshRenderer>().material.SetColor("_ColorTint", Random.ColorHSV());
                t1.transform.position = _point1.position;
                t2.transform.position = _point2.position;
                Vector3 direction1 = new Vector3(1, Random.Range(_leftDirectionRate.y, _rightDirectionRate.y),
                    Random.Range(_leftDirectionRate.z, _rightDirectionRate.z)) * _force;
                Vector3 direction2 = -direction1;
                t1.GetComponent<Rigidbody>().AddForce(direction1, ForceMode.Impulse);
                t2.GetComponent<Rigidbody>().AddForce(direction2, ForceMode.Impulse);
            }
            yield return new WaitForSeconds(_duration);
        }
    }
}
