using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{

    [SerializeField]
    float zoomOutValue = 15f;

    [SerializeField]
    bool zoomOut = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Camera camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

            if (zoomOut)
            {
               camera.orthographicSize = zoomOutValue;
            }
            else
            {
                camera.orthographicSize = 6f;
            }
            
        }
            

    }

}
