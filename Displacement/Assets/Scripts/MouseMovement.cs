using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseMovement : MonoBehaviour // rotate character to mouse position
{
    private Vector3 _mousePosition;
    [SerializeField] private Transform _gunPosition;
    void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapPoint(_mousePosition);
        bool mouseMovement = true;
        if (collider != null && collider.gameObject.CompareTag("TurningPoint"))
        {
            mouseMovement = false;
        }
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = _mousePosition - _gunPosition.transform.position;
        difference.Normalize();
        if (mouseMovement)
        {
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        }
    }
}