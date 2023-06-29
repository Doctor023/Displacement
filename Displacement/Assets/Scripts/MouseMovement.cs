using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        // ��� ����� �������
        // ��������� ������� ����� ������� ���������� � ���������� ����
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        // ����������� ����������� ���� ��������
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // ��������� ������� ������ ��� Z
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}