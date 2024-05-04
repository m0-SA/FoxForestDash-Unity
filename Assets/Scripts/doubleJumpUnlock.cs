using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class doubleJumpUnlock : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerController.Instance.doubleJumpUnlocked == false)
            {
                PlayerController.Instance.doubleJumpUnlocked = true;
                StartCoroutine(unlockUIText());
            }
                
        }
    }

    IEnumerator unlockUIText()
    {
        GameObject unlockUI = GameObject.FindWithTag("UnlockUI");
        TextMeshProUGUI unlockText = unlockUI.GetComponent<TextMeshProUGUI>();
        unlockText.text = "You've unlocked double jump!";
        // removes double jump unlock collectable
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        unlockText.text = "";
        Destroy(gameObject);
    }

}
