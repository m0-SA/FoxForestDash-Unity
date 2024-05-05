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
            //
            GameObject.FindWithTag("LevelCheckpoint").SetActive(false);
            transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();
            StartCoroutine(loadScene(scene,other));
        }
    }


    IEnumerator loadScene(int level, Collider2D other)
    {
        // begins transition animation. Player health set to max, player position set to 0 and next scene loaded while screen is black.
        transition.SetTrigger("loadOut");
        yield return new WaitForSeconds(1);
        other.transform.position = Vector3.zero;
        health.Instance.playerHealth = health.Instance.maxHealth;
        SceneManager.LoadScene(level);
        transition.SetTrigger("loadIn");
    }
}
