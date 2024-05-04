using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkpointText : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(checkpoint());
        }
    }

    IEnumerator checkpoint()
    {
        TextMeshProUGUI checkpointUI = GameObject.FindWithTag("UnlockUI").GetComponent<TextMeshProUGUI>();
        checkpointUI.text = "Checkpoint Unlocked";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        checkpointUI.text = "";
    }
}
