using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
    public float bounce = 10f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
