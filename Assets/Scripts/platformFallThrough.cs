using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class platformFallThrough : MonoBehaviour
{

    [SerializeField]
    float fallTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(platformFall());
        }
    }

    IEnumerator platformFall()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(fallTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }


}
