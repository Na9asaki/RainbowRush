using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneration : MonoBehaviour
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRadius;

    private List<Ball> _objects;
    public static int CountObject = 0;
    public List<Ball> Objects => _objects;

    private void OnEnable()
    {
        InputConverter.OnConverted += Generate;
    }

    private void OnDisable()
    {
        InputConverter.OnConverted -= Generate;
    }

    public void Generate(int countObjects)
    {
        if (_objects == null)
        {
            _objects = new List<Ball> (countObjects);
            CountObject = 0;
        } 
        if (countObjects >= CountObject)
        {
            countObjects -= CountObject;
        } else
        {
            int n = CountObject - countObjects;
            for (int i = 0; i < n; i++)
            {
                _objects[0].Delete();
                _objects.RemoveAt(0);
            }
            CountObject = _objects.Count;
            countObjects = 0;
        }
        for (int i = 0; i < countObjects; i++)
        {
            var point = Random.insideUnitSphere * _spawnRadius + _spawnPoint.position;
            var obj = Instantiate(_prefab, point, Quaternion.identity);
            obj.Init();
            _objects.Add(obj);
            CountObject = _objects.Count;
        }

    }

    public void Shuffle()
    {
        if (CountObject == 0) return;
        for (int i = 0; i < _objects.Count; i++)
        {
            var point = Random.insideUnitSphere * _spawnRadius + _spawnPoint.position;
            _objects[i].transform.position = point;
        }
    }

    public void ResetObjects()
    {
        _objects = null;
    }
}
