using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{


    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*|| other.CompareTag("Ground")*/)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
    }
}
