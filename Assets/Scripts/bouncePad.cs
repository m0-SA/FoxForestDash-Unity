using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
    public float bounce = 10f;
    float jbTimeCurrent;
    float coyoteTimeCurrent;

    void Start()
    {
        jbTimeCurrent = PlayerController.Instance.jbTime;
        coyoteTimeCurrent = PlayerController.Instance.coyoteTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        StartCoroutine(coyoteExtension());
      
    }

    private void Update()
    {
        if (PlayerController.Instance.isGrounded())
        {
            Reset();
        }
    }

    private void Reset()
    {
        PlayerController.Instance.coyoteTime = coyoteTimeCurrent;
        PlayerController.Instance.jbTime = jbTimeCurrent;
        PlayerController.Instance.doubleJump = true;
        
    }
    // Makes sure the player can peform one jump after bouncing.

    IEnumerator coyoteExtension()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerController.Instance.coyoteTime = 0.5f;
        PlayerController.Instance.jbTime = 0.5f;
        PlayerController.Instance.doubleJump = true;
    }

}
