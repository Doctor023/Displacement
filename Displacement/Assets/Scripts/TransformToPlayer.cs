using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Update()
    {
        Vector2 playerPosition = _player.transform.position;
        transform.position = new Vector3 (playerPosition.x, playerPosition.y, -1);
    }
}
