using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrawLine : MonoBehaviour
{
    private Vector2 _mousePosition;
    [SerializeField] private Transform _gunPosition;
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(_gunPosition.transform.position, _mousePosition, Color.blue);

    }
}
