using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rideable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // setting parent removes from "DontDestroyOnLoad" heirarchy. 
        if (collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);

        // Puts back into "DontDestroyOnLoad"
        DontDestroyOnLoad(collision.gameObject);
    }
}