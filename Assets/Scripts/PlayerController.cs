using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    private bool _isOnGround;
    public bool gameOver;

    private void Reset()
    {
        jumpForce = 10f;
        gravityModifier = 1.5f;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _isOnGround = true;
        gameOver = false;
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            return;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            return;
        }
            
    }
}