using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
public class loadLevel : MonoBehaviour
{

    public int scene;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
            other.transform.position = Vector3.zero;
            health.Instance.playerHealth = health.Instance.maxHealth;
        }
    }
    
}
