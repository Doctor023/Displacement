using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] float _visibilityRange;

    [SerializeField] Transform _playerTransform;
    [SerializeField] SpriteRenderer _exclamationPoint;

    float _distanceToPlayer;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        _playerTransform = player.transform;
    }

    void Update()
    {      
        DrawCircle();
        DrawEyeVision();
        _distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);
        Debug.Log(_distanceToPlayer);
        if (CheckCircleVision() || CheckForwardVision())
        {
            UnityEngine.Color color = _exclamationPoint.color;
            color.a = 100;
            _exclamationPoint.color = color;
        }
        else
        {
            UnityEngine.Color color = _exclamationPoint.color;
            color.a = 0;
            _exclamationPoint.color = color;
        }
    }

    bool CheckForwardVision()
    {
        Vector2 right = transform.right * _visibilityRange;
        Vector2 vectorToPlayer = _playerTransform.position - transform.position;
        float angle = Vector2.Angle(vectorToPlayer, right);
        if(_distanceToPlayer <= _visibilityRange && angle <= 45f)
        {
            return true;
        }
        return false;
    }
    bool CheckCircleVision()
    {
        if (_distanceToPlayer <= _radius)
        {
            return true;
        }
        return false;
    }

    void DrawCircle()
    {
        int segments = 64;
        float angle = 360f / segments;
        Vector3 previousPoint = transform.position;
        Vector3 firstPoint = transform.position;

        for (int i = 0; i <= segments; i++)
        {
            float theta = angle * i;
            float x = _radius * Mathf.Cos(Mathf.Deg2Rad * theta);
            float y = _radius * Mathf.Sin(Mathf.Deg2Rad * theta);

            Vector3 currentPoint = new Vector3(x, y, 0f) + transform.position;

            if (i > 0)
            {
                Debug.DrawLine(previousPoint, currentPoint, UnityEngine.Color.red);
            }
            else
            {
                firstPoint = currentPoint;
            }

            previousPoint = currentPoint;
        }

        Debug.DrawLine(previousPoint, firstPoint, UnityEngine.Color.red);
    }

    void DrawEyeVision()
    {
        Quaternion rotationPositive = Quaternion.Euler(0, 0, 45);
        Quaternion rotationNegative = Quaternion.Euler(0, 0, -45);
        Vector3 right = transform.position + transform.right * 20;

        Vector3 rotatedDirectionPositive = rotationPositive * right;
        Vector3 rotatedDirectionNegative = rotationNegative * right;

        Debug.DrawLine(transform.position, right);
        Debug.DrawLine(transform.position, rotatedDirectionNegative, UnityEngine.Color.red);
        Debug.DrawLine(transform.position, rotatedDirectionPositive, UnityEngine.Color.red);
        Debug.DrawLine(rotatedDirectionNegative, right, UnityEngine.Color.red);
        Debug.DrawLine(rotatedDirectionPositive, right, UnityEngine.Color.red);
    }
}
