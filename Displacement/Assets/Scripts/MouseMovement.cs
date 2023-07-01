using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private float _correctionGun;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        // “от самый поворот
        // вычисл€ем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        // вычисл€емый необходимый угол поворота
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + _correctionGun;
        // ѕримен€ем поворот вокруг оси Z
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}