using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Vector2 _moveDir;
    Rigidbody2D _rb;
    Animator _anim;

    [SerializeField] Transform attackTransform;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask attackableLayer;

    [SerializeField] GameObject Boomerang;

    RaycastHit2D[] hits;
    [SerializeField] Vector3 capSize;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();

        if (InputManager.isAttacking)
        {
            ThrowBoomerang();
            _anim.SetTrigger("attack");
        }
    }

    private void MovePlayer()
    {
        _moveDir.Set(InputManager.Movement.x, InputManager.Movement.y);
        _rb.velocity = _moveDir * _moveSpeed;
    }

    private void ThrowBoomerang()
    {
        Instantiate(Boomerang, transform.position+Vector3.up, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            SceneManager.LoadScene("3_EndScene");
        }
    }
}
