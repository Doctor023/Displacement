using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _feet;
    private Animator _feetAnimator;
    private Vector2 _movement;
    private void Start()
    {
        _feetAnimator = _feet.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _movement = new Vector2(0, 0); 
        Movement();        
        if (_movement.magnitude > 0)
        {
            Debug.Log("Move true");
            _feetAnimator.SetBool("Move", true);
        }
        else
        {
            Debug.Log("Move false");
            _feetAnimator.SetBool("Move", false);
        }
        if (_movement.magnitude > 1)
        {
            _movement.Normalize();
        }      
        transform.Translate(_movement * _speed);
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movement += new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _movement += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            _movement += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movement += new Vector2(0, -1);
        }
    }
}