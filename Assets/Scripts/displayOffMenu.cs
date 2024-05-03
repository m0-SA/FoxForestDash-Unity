using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class displayOffMenu : MonoBehaviour
{

    void Awake()
    {
  
        GameObject backButton = GameObject.FindWithTag("Back");
        backButton.GetComponent<Button>().enabled = false;
        backButton.GetComponent<Image>().enabled = false;
        backButton.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        GameObject health = GameObject.FindWithTag("HealthBar");
        health.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        TextMeshProUGUI dashText = GameObject.FindWithTag("DashText").GetComponent<TextMeshProUGUI>();
        dashText.text = "";

        GameObject[] menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
        foreach (GameObject button in menuButtons)
        {
            button.GetComponent<Button>().enabled = true;
            button.GetComponent<Image>().enabled = true;
            button.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        }

        TextMeshProUGUI unlockUI = GameObject.FindWithTag("UnlockUI").GetComponent<TextMeshProUGUI>();
        unlockUI.text = "";

        TextMeshProUGUI tutorialUI = GameObject.FindWithTag("TutorialText").GetComponent<TextMeshProUGUI>();
        tutorialUI.text = "";

    }

    // Start is called before the first frame update
    void Start()
    {
        health.Instance.playerHealth = -1;
        health.Instance.maxHealth = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
