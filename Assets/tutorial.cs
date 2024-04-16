using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{

    public TextMeshProUGUI tutorialUI;
    public string tutorialText;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialUI.text = tutorialText;
        }
    }
}
