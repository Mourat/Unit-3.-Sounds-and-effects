using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWidth;

    private void Awake()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}