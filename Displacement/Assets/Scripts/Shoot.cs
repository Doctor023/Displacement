using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _shootDelay;

    private bool _blockShoot; // block shoot if bool is true

    void Start()
    {

    }
    void Update()
    {
        _blockShoot = _animator.GetBool("Shoot"); // check that shot didn't fired yet

        if (!_blockShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetBool("Shoot", true);
            Instantiate(_bullet, _gunBarrel.position, _gunBarrel.rotation); // spawn bullet
        }
    }

    void StopShootAnim()
    {
        _animator.SetBool("Shoot", false);
    }
}
