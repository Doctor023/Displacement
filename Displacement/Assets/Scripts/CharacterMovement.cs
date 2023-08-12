using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _feet;
    [SerializeField] private GameObject _body;
    private Animator _feetAnimator;
    private Vector3 _movement;
    private Transform _feetTransform;
    private Transform _bodyTransform;
    private Vector3 _mousePosition;
    float _difference;
    private void Start()
    {
        _feetAnimator = _feet.GetComponent<Animator>(); // work with feet's animation
        _feetTransform = _feet.transform; // work with feet's transform
        _bodyTransform = _body.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Debug.DrawLine(_feetTransform.position, _feetTransform.position + _feetTransform.TransformDirection(Vector3.right) * 5);
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _movement = new Vector3(0, 0);
        Movement();
        if (_movement.magnitude > 1) // нормализация вектора передвижения при движении по диагонали
        {
            _movement.Normalize();
        }
        transform.Translate(_movement * _speed, Space.World); // передвижение персонажа
        if (_movement.magnitude == 0) // персонаж стоит
        {
            _feetAnimator.SetBool("Move", false); // останавливается анимация движения ног
            _feetTransform.rotation = _bodyTransform.rotation; // позиция ног = позиции направления тела
        }
        if (_movement.magnitude > 0)// персонаж бежит
        {
            _feetAnimator.SetBool("Move", true); // запускается анимация движения ног
            FeetRotation(); // запускается метод вращения ног персонажа
        }
    }
    void Movement() // определение вектора движения
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movement += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            _movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movement += new Vector3(0, -1, 0);
        }
    }
    void FeetRotation()
    {
        float zAngle = Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg; // определяется градус поворота для ног
        _feetTransform.rotation = Quaternion.Euler(0, 0, zAngle);
    }
}