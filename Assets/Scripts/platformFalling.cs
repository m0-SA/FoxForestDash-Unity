using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFalling : MonoBehaviour
{
    public float disableDelay = 1f;
    public float enableDelay = 1f;

    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerController.Instance.isGrounded()) {
            collision.transform.SetParent(null);
            StartCoroutine(platformFalls());
        }
    }

    IEnumerator platformFalls()
    {
        //disabling and enabling platforms.
        yield return new WaitForSeconds(disableDelay);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(enableDelay);

        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
