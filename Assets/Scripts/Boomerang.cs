using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            // The enemy class will handle this in the future.
            Destroy(collision.gameObject);

            // Give points to the player
            GameManager.Instance.AddPoints();
        }
        if(collision.tag == "Despawn Zone")
        {
            Destroy(gameObject);
        }
    }
}
