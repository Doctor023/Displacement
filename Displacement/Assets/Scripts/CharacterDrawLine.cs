using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrawLine : MonoBehaviour
{
    private Vector2 _mousePosition;
    [SerializeField] private float _distance = 10f;
    private Vector2 _direction;
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(transform.position, _mousePosition, Color.blue);
        _direction = transform.position + transform.right * _distance;
        Debug.DrawLine(transform.position, _direction);

    }
}
