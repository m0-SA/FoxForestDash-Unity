using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class unlockClear : MonoBehaviour
{
    public TextMeshProUGUI unlockUI;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            unlockUI.text = "";
        }
    }
}
