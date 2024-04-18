using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoveryCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;

    public health health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = checkpoint.transform.position;
            health.damage();
        }
    }
}
