using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class platformFallThrough : MonoBehaviour
{

    [SerializeField]
    float fallTime = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(platformFall());
        }
    }

    IEnumerator platformFall()
    {
        // temp disable collider to allow player fall.
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(fallTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }


}
