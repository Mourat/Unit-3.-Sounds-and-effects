using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed;

    private void Awake()
    {
        _speed = 15f;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * _speed));
    }
}
