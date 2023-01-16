using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    private bool _isOnGround;
    public bool gameOver;
    private Animator _playerAnim;

    private void Reset()
    {
        jumpForce = 10f;
        gravityModifier = 1.5f;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _isOnGround = true;
        gameOver = false;
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            _playerAnim.SetInteger("DeathType_int", 1);
            _playerAnim.SetBool("Death_b", true);
        }
            
    }
}