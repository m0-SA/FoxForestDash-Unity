using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class heartUnlock : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.Instance.maxHealth += 1;
            health.Instance.playerHealth = health.Instance.maxHealth;
            StartCoroutine(heartUIText());
            
        }
    }

    IEnumerator heartUIText()
    {
        TextMeshProUGUI unlockUI = GameObject.FindWithTag("UnlockUI").GetComponent<TextMeshProUGUI>();
        unlockUI.text = "You've gained a heart!";
        // removes heart unlock collectable interact. Only destroy once text is cleared.
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        unlockUI.text = "";
        Destroy(gameObject);
    }
}
