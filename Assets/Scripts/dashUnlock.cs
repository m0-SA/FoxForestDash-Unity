using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dashUnlock : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerController.Instance.dashUnlocked == false)
            {
                PlayerController.Instance.dashUnlocked = true;
                PlayerController.Instance.canRollDash = true;
                StartCoroutine(unlockUIText());
            }
            
        }
    }
    IEnumerator unlockUIText()
    {

        TextMeshProUGUI unlockText = GameObject.FindWithTag("UnlockUI").GetComponent<TextMeshProUGUI>();
        unlockText.text = "You've unlocked dash!";
        TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
        dashText.text = "Dash Available";
        dashText.color = Color.green;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        unlockText.text = "";
        Destroy(gameObject);
    }
}
