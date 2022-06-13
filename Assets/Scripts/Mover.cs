using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private int _directionLeft = 180;
    private int _directionRight = 0;
    private const string _walk = "Walk";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(_directionRight);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(_directionLeft);
        }
    }

    private void MovePlayer(int rotation)
    {
        transform.rotation = Quaternion.Euler(0, rotation, 0);
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        _animator.SetTrigger(_walk);
    }
}
