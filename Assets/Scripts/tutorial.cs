using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{


    public string tutorialOutput;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextMeshProUGUI tutorialUI = GameObject.FindWithTag("TutorialText").GetComponent<TextMeshProUGUI>();
            tutorialUI.text = tutorialOutput;
        }
    }
}
