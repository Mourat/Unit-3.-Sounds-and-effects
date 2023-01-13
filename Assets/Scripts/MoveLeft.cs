using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed;
    private PlayerController _playerController;
    private float _leftBound;

    private void Awake()
    {
        _speed = 15f;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _leftBound = -10;
    }

    private void Update()
    {
        if (!_playerController.gameOver)
            transform.Translate(Vector3.left * (Time.deltaTime * _speed));
        
        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
