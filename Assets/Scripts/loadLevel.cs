using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{

    public int scene;
    public Animator transition;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("LevelCheckpoint").SetActive(false);
            StartCoroutine(loadScene(scene,other));

        }

    }


    IEnumerator loadScene(int level, Collider2D other)
    {
        transition.SetTrigger("loadOut");
        yield return new WaitForSeconds(1);
        other.transform.position = Vector3.zero;
        health.Instance.playerHealth = health.Instance.maxHealth;
        SceneManager.LoadScene(level);
    }
}
