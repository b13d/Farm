using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;

    [SerializeField]
    Animator _animatorPlayer;

    Rigidbody2D _rb;

    float horizontal;
    float vertical;

    float _moveLimiter = .7f;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        KeyDown();

        KeyUp();
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= _moveLimiter;
            vertical *= _moveLimiter;
        }

        _rb.velocity = new Vector2(horizontal * _speed, vertical * _speed);
    }

    void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimationMove("forward");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AnimationMove("down");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimationMove("left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimationMove("right");
        }
    }

    void KeyUp()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            StopAnimationMove("forward");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            StopAnimationMove("down");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            StopAnimationMove("left");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            StopAnimationMove("right");
        }
    }

    void StopAnimationMove(string nameAnim)
    {
        switch (nameAnim)
        {
            case "forward":
                _animatorPlayer.SetBool("moveForward", false);
                break;
            case "down":
                _animatorPlayer.SetBool("moveDown", false);
                break;
            case "left":
                _animatorPlayer.SetBool("moveLeft", false);
                break;
            case "right":
                _animatorPlayer.SetBool("moveRight", false);
                break;
        }
    }

    public void AnimationMove(string nameAnim)
    {
        switch (nameAnim)
        {
            case "forward":
                _animatorPlayer.SetBool("moveForward", true);
                break;
            case "down":
                _animatorPlayer.SetBool("moveDown", true);
                break;
            case "left":
                _animatorPlayer.SetBool("moveLeft", true);
                break;
            case "right":
                _animatorPlayer.SetBool("moveRight", true);
                break;
        }
    }
}
