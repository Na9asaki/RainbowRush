using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] private ObjectGeneration _objectGeneration;
    [SerializeField] private float _smoothTime = 1;
    private Vector3 _target;
    private bool _active = false;

    private void FixedUpdate()
    {
        if (!_active) return;
    }

    private void LateUpdate()
    {
        if (!_active) return;
        float firstBallPosition = _objectGeneration.Objects[0].transform.position.y;
        for (int i = 0; i < _objectGeneration.Objects.Count; i++)
        {
            float t = _objectGeneration.Objects[i].transform.position.y;
            if (t < firstBallPosition)
            {
                firstBallPosition = t;
            }
        }
        _target = new Vector3(transform.position.x, firstBallPosition, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _target, _smoothTime);
    }

    public void Activate()
    {
        if (ObjectGeneration.CountObject == 0) return;
        _active = true;
    }
}
