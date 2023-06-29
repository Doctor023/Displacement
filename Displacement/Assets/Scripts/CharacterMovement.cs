using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector2(0, -1);
        }

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        transform.Translate(movement * _speed);
    }
}