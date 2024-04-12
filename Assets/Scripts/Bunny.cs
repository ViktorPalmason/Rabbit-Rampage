using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    // Stats
    [SerializeField] float _moveSpeed = 5f;

    // Components
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * _moveSpeed;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Despawn Zone") 
        {
            Destroy(gameObject);
        }
    }
}
