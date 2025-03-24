using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 9.8f;
    private Vector2 _moveInput;
    private CharacterController _controller;
    public AnimationPlayer animator;
    private Vector3 _velocity;
    private Vector3 move;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
    public void OnAttack(InputValue value)
    {
        if (value.isPressed) 
        {
            ShootAnim();
        }
    }
    private void Update()
    {
        move = new Vector3(_moveInput.x, 0, _moveInput.y);
        _controller.Move(move * speed * Time.deltaTime);
        
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
        }

        AnimationRunningPlayer();
        
        if (!_controller.isGrounded)
        {
            _velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            _velocity.y = -0.1f;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void AnimationRunningPlayer()
    {
        animator.RunAnimation(move != Vector3.zero);
    }
    
    private void ShootAnim()
    {
        animator.ShootAnimation();
    }
}
