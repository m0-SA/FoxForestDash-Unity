using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class platformFallThrough : MonoBehaviour
{

    [SerializeField]
    float fallTime = 1.0f;
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
