using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController _playerController;
    private float _leftBound;

    private void Reset()
    {
        speed = 30f;
    }

    private void Awake()
    {
        // _speed = 50f;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _leftBound = -10;
    }

    private void Update()
    {
        if (!_playerController.gameOver)
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        
        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
